using PaddleBilling.Http.Converters;
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
            new DefaultItemTypeConverter(),
            new NullableItemTypeConverter(),
            new NullableTaxCategoryConverter(),
            new DefaultTaxCategoryConverter(),
            new EventConverter()
        }
    };
}