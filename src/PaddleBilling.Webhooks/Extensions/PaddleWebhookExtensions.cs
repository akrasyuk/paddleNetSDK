using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PaddleBilling.Webhooks.Middleware;

namespace PaddleBilling.Webhooks.Extensions;

public static class PaddleWebhookExtensions
{
    public static IServiceCollection AddPaddleWebhooks(this IServiceCollection services, Action<PaddleWebhookHandlerRegistry> configure)
    {
        var registry = new PaddleWebhookHandlerRegistry();
        configure(registry);

        services.AddSingleton(registry);

        foreach (var handlerType in registry.GetHandlers())
        {
            services.AddScoped(handlerType);
        }

        return services;
    }

    public static IApplicationBuilder UsePaddleWebhooks(this IApplicationBuilder app)
    {
        var registry = app.ApplicationServices.GetRequiredService<PaddleWebhookHandlerRegistry>();
        return app.UseMiddleware<PaddleWebhookMiddleware>(registry);
    }
}