using System.Text.Json;
using PaddleBilling.Models.Json.Converters;

namespace PaddleBilling.Models.Json.Aot;

public static class PaddleBillingSerializerOptions
{
    public static void Defaults(JsonSerializerOptions options)
    {
        options.PropertyNameCaseInsensitive = true;
        options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
        options.WriteIndented = true;

        foreach (var converter in ItemTypeConverter.GetConverters())
            options.Converters.Add(converter);
        foreach (var converter in TaxCategoryConverter.GetConverters())
            options.Converters.Add(converter);
    }
}