using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaddleBilling.Http.API.v1;
using PaddleBilling.Http.Extensions;
using PaddleBilling.Http.Options;


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

var products = await client.GetProductsAsync();

Console.ReadLine();