using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleBilling.Models.API.v1.Resources.Enums;

namespace PaddleBilling.Models.Json.Converters;

public class TaxCategoryConverter : JsonConverter<TaxCategory?>
{
    public override TaxCategory? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();

        if (stringValue is not null)
        {
            return stringValue switch
            {
                "digital-goods" => TaxCategory.DigitalGoods,
                "ebooks" => TaxCategory.Ebooks,
                "implementation-services" => TaxCategory.ImplementationServices,
                "professional-services" => TaxCategory.ProfessionalServices,
                "saas" => TaxCategory.Saas,
                "software-programming-services" => TaxCategory.SoftwareProgrammingServices,
                "standard" => TaxCategory.Standard,
                "training-services" => TaxCategory.TrainingServices,
                "website-hosting" => TaxCategory.WebsiteHosting,
                _ => throw new JsonException($"Unable to convert \"{stringValue}\" to Enum \"{nameof(TaxCategory)}\".")
            };
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, TaxCategory? value, JsonSerializerOptions options)
    {
        if (value is not null)
        {
            var stringValue = value switch
            {
                TaxCategory.DigitalGoods => "digital-goods",
                TaxCategory.Ebooks => "ebooks",
                TaxCategory.ImplementationServices => "implementation-services",
                TaxCategory.ProfessionalServices => "professional-services",
                TaxCategory.Saas => "saas",
                TaxCategory.SoftwareProgrammingServices => "software-programming-services",
                TaxCategory.Standard => "standard",
                TaxCategory.TrainingServices => "training-services",
                TaxCategory.WebsiteHosting => "website-hosting",
                _ => throw new JsonException($"Unable to serialize \"{value}\" of Enum \"{nameof(TaxCategory)}\".")
            };
            writer.WriteStringValue(stringValue);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}