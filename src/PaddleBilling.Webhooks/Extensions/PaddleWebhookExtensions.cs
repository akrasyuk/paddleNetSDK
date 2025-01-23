using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PaddleBilling.Webhooks.Configuration;
using PaddleBilling.Webhooks.Middleware;
using PaddleBilling.Webhooks.Services;

namespace PaddleBilling.Webhooks.Extensions;

public static class PaddleWebhookExtensions
{
    public static IServiceCollection AddPaddleWebhooks(this IServiceCollection services, Action<PaddleWebhookConfiguration> configure)
    {
        var configuration = new PaddleWebhookConfiguration();
        configure(configuration);

        services.AddSingleton(configuration);
        services.AddSingleton<IPaddleSignatureValidator, PaddleSignatureValidator>();

        foreach (var handlerInfo in configuration.GetHandlers())
        {
            services.AddScoped(handlerInfo.HandlerType);
        }

        return services;
    }

    public static IApplicationBuilder UsePaddleWebhooks(this IApplicationBuilder app)
    {
        var registry = app.ApplicationServices.GetRequiredService<PaddleWebhookConfiguration>();
        return app.UseMiddleware<PaddleWebhookMiddleware>(registry);
    }
}