using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleBilling.Models.API.v1.Resources.Enums;

namespace PaddleBilling.Models.Json.Converters;

public class NullableItemTypeConverter : JsonConverter<ItemType?>
{
    public override ItemType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();
        if (stringValue is not null)
        {
            return stringValue switch
            {
                "standard" => ItemType.Standard,
                "custom" => ItemType.Custom,
                _ => throw new JsonException($"Unable to convert \"{stringValue}\" to Enum \"{nameof(ItemType)}\".")
            };
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, ItemType? value, JsonSerializerOptions options)
    {
        if (value is not null)
        {
            var stringValue = value switch
            {
                ItemType.Standard => "standard",
                ItemType.Custom => "custom",
                _ => throw new JsonException($"Unable to serialize \"{value}\" of Enum \"{nameof(ItemType)}\".")
            };
            writer.WriteStringValue(stringValue);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}

public class DefaultItemTypeConverter : JsonConverter<ItemType>
{
    public override ItemType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();

        if (string.IsNullOrWhiteSpace(stringValue))
            throw new JsonException("Unable to convert null to Enum.");

        return stringValue switch
        {
            "standard" => ItemType.Standard,
            "custom" => ItemType.Custom,
            _ => throw new JsonException($"Unable to convert \"{stringValue}\" to Enum \"{nameof(ItemType)}\".")
        };
    }

    public override void Write(Utf8JsonWriter writer, ItemType value, JsonSerializerOptions options)
    {

        var stringValue = value switch
        {
            ItemType.Standard => "standard",
            ItemType.Custom => "custom",
            _ => throw new JsonException($"Unable to serialize \"{value}\" of Enum \"{nameof(ItemType)}\".")
        };
        writer.WriteStringValue(stringValue);
    }
}

public static class ItemTypeConverter
{
    public static ICollection<JsonConverter> GetConverters() =>
        [new NullableItemTypeConverter(), new DefaultItemTypeConverter()];
}