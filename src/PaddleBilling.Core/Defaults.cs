using System.Text.Json.Serialization;
using System.Text.Json;

namespace PaddleBilling.Core;

public static class Defaults
{
    public static TimeSpan DefaultHttpClientTimeout { get; set; } = TimeSpan.FromSeconds(20);

    public static JsonSerializerOptions DefaultJsonSerializerOptions { get; set; } = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };
}