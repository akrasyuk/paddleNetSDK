using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PaddleBilling.Http.API.v1;
using PaddleBilling.Http.Options;

namespace PaddleBilling.Http.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddPaddleClient(this IServiceCollection services, PaddleClientOptions options)
    {
        _ = services.AddHttpClient(options.HttpClientName)
            .AddTypedClient((httpClient, serviceProvider) =>
            {
                httpClient.BaseAddress = new Uri(options.BaseUrl);
                httpClient.Timeout = options.HttpClientTimeout;
                httpClient.DefaultRequestHeaders.UserAgent.Clear();
                httpClient.DefaultRequestHeaders.UserAgent
                    .Add(new ProductInfoHeaderValue(
                        "PaddleBillingNetSDK",
                        Assembly.GetExecutingAssembly().GetFlexibleSemVersion()));
                httpClient.DefaultRequestHeaders.Add("Version", options.Version);
                return new PaddleClient(serviceProvider.GetRequiredService<ILogger<PaddleClient>>(), httpClient,
                    options);
            });
    }
}