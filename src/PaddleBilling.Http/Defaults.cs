using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleBilling.Http.Converters;
using PaddleBilling.Models.API.v1.Resources.Enums;
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
            new ItemTypeConverter(),
            new TaxCategoryConverter(),
            new BidirectionalJsonStringEnumConverter<ItemType>(),
            new BidirectionalJsonStringEnumConverter<TaxCategory>(),
            new EventConverter()
        }
    };
}