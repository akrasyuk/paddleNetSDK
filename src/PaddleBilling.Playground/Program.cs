using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaddleBilling.Core.API.v1;
using PaddleBilling.Core.Extensions;
using PaddleBilling.Core.Options;



var serverUrl = "https://sandbox-api.paddle.com/";

var key = Environment.GetEnvironmentVariable("PADDLE_KEY");

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddPaddleClient(new PaddleClientOptions
        {
            BaseUrl = serverUrl,
            ApiKey = key,
            Version = "1"
        });
    })
    .Build();

var client = host.Services.GetRequiredService<PaddleClient>();

var notSettings = await client.GetNotificationSettingsAsync();

Console.ReadLine();