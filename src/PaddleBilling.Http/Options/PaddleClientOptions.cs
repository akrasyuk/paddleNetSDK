namespace PaddleBilling.Http.Options;

public class PaddleClientOptions
{
    public string HttpClientName { get; set; } = "Paddle.Client";

    public string BaseUrl { get; set; }

    public string ApiKey { get; set; }

    public string Version { get; set; } = "1";

    public TimeSpan HttpClientTimeout { get; set; } = Defaults.DefaultHttpClientTimeout;
}