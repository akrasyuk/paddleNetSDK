using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PaddleBilling.Core.API.v1.Resources.NotificationsAndEvents;
using PaddleBilling.Core.API.v1.Resources;
using PaddleBilling.Core.Converters;
using System.Text.Json;
using PaddleBilling.Core.API.v1.Resources.Enums;
using PaddleBilling.Core.Extensions;

namespace PaddleBilling.Webhooks.Middleware;

public class PaddleWebhookMiddleware(RequestDelegate next, PaddleWebhookHandlerRegistry registry)
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
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var @event = JsonSerializer.Deserialize<Event<Entity>>(body);

            using var scope = serviceProvider.CreateScope();
            var scopedProvider = scope.ServiceProvider;

            if (@event != null && registry.TryGetHandler(@event.EventType, out var handlerType))
            {
                var handler = scopedProvider.GetRequiredService(handlerType);

                var payloadType = @event.EventType.GetPayloadType();

                var genericEventType = typeof(Event<>).MakeGenericType(payloadType);

                var specificEvent = Activator.CreateInstance(
                    genericEventType,
                    @event.EventId,
                    @event.EventType,
                    @event.OccurredAt,
                    @event.NotificationId,
                    Convert.ChangeType(@event.Data, payloadType)
                );

                var method = handlerType.GetMethod("HandleAsync");
                await (Task)method.Invoke(handler, new[] { specificEvent });
                context.Response.StatusCode = StatusCodes.Status200OK;
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status200OK;
                await context.Response.WriteAsync("No handler registered for the event type.");
            }
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsync($"Error processing webhook: {ex.Message}");
        }
    }

    private bool IsValidRequest(HttpContext context)
    {
        if(!context.Request.Path.StartsWithSegments(registry.Endpoint))
            return false;

        if(context.Request.Method != HttpMethods.Post)
            return false;

        if (context.Request.ContentLength is null or 0)
            return false;

        //TODO: Introduce Paddle signature verification

        return true;
    }
}