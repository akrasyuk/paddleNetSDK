using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleBilling.Http.Converters;
using PaddleBilling.Models.Json.Converters;

namespace PaddleBilling.Http;

public static class Defaults
{
    public static TimeSpan DefaultHttpClientTimeout { get; set; } = TimeSpan.FromSeconds(20);

    public static JsonSerializerOptions DefaultJsonSerializerOptions { get; set; } = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Converters =
        {
            new EventTypeConverter(),
            new DefaultItemTypeConverter(),
            new NullableItemTypeConverter(),
            new DefaultTaxCategoryConverter(),
            new NullableTaxCategoryConverter(),
            new EventConverter()
        }
    };
}