using PaddleBilling.Http.Converters;
using PaddleBilling.Models.API.v1.Resources.Enums;
using System.Text.Json.Serialization;
using System.Text.Json;
using PaddleBilling.Models.Json.Converters;

namespace PaddleBilling.Webhooks;

public static class Defaults
{
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