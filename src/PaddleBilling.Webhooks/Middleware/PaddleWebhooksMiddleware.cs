using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PaddleBilling.Core.API.v1.Resources.NotificationsAndEvents;
using PaddleBilling.Core.API.v1.Resources;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using PaddleBilling.Webhooks.Configuration;
using PaddleBilling.Webhooks.Services;

namespace PaddleBilling.Webhooks.Middleware;

public class PaddleWebhookMiddleware(
    RequestDelegate next,
    PaddleWebhookConfiguration configuration,
    ILogger<PaddleWebhookMiddleware> logger,
    IPaddleSignatureValidator validator)
{
    public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
    {
        if (!IsValidRequest(context))
        {
            await next(context);
            return;
        }

        try
        {
            var @event = await ExtractEvent(context);

            if (@event is not null && configuration.TryGetHandler(@event.EventType, out var handlerInfo))
            {
                using var scope = serviceProvider.CreateScope();
                var scopedProvider = scope.ServiceProvider;

                var handler = scopedProvider.GetRequiredService(handlerInfo.HandlerType);

                var specificEvent = ExtractSpecificEvent(handlerInfo, @event);

                await InvokeHandler(handler, handlerInfo.HandleMethod, specificEvent);
            }

            context.Response.StatusCode = StatusCodes.Status200OK;
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsync($"Error processing webhook: {ex.Message}");
        }
    }

    private async Task InvokeHandler(object handler, MethodInfo method, object args)
    {
        try
        {
            await ((Task)method.Invoke(handler, [args]))!;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error invoking handler method.");
        }
    }

    private object ExtractSpecificEvent(WebhookHandlerInfo handlerInfo, Event<Entity> @event)
    {
        try
        {
            var specificEvent = Activator.CreateInstance(
                handlerInfo.ParameterType,
                @event.EventId,
                @event.EventType,
                @event.OccurredAt,
                @event.NotificationId,
                Convert.ChangeType(@event.Data, handlerInfo.GenericType)
            );
            return specificEvent;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error extracting specific event from generic event.");
            return default;
        }
    }

    private async Task<Event<Entity>> ExtractEvent(HttpContext context)
    {
        try
        {
            using var reader = new StreamReader(context.Request.Body);
            var body = await reader.ReadToEndAsync();

            if (configuration.ValidateSignature)
            {
                var signature = context.Request.Headers["Paddle-Signature"];
                if (!validator.ValidateSignature(signature, body))
                {
                    logger.LogWarning("Invalid signature in request.");
                    return default;
                }
            }

            var @event = JsonSerializer.Deserialize<Event<Entity>>(body);

            return @event;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deserializing event from request body.");
            return default;
        }
    }

    private bool IsValidRequest(HttpContext context)
    {
        if(!context.Request.Path.StartsWithSegments(configuration.Endpoint))
            return false;

        if(context.Request.Method != HttpMethods.Post)
            return false;

        if (context.Request.ContentLength is null or 0)
            return false;

        return true;
    }
}