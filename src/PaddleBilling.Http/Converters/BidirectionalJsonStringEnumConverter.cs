using System.Collections.Immutable;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleBilling.Http.Converters;

public class BidirectionalJsonStringEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    private static readonly Lazy<ImmutableDictionary<T, string>> ToStringMap = new(() =>
        typeof(T)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .ToImmutableDictionary(
                field => (T)field.GetValue(null)!,
                field => field.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? field.Name
            )
    );

    private static readonly Lazy<ImmutableDictionary<string, T>> FromStringMap = new(() =>
        ToStringMap.Value.ToImmutableDictionary(
            kvp => kvp.Value,
            kvp => kvp.Key,
            StringComparer.OrdinalIgnoreCase
        )
    );

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();
        if (stringValue is not null && FromStringMap.Value.TryGetValue(stringValue, out var value))
        {
            return value;
        }

        throw new JsonException($"Unable to convert \"{stringValue}\" to Enum \"{typeof(T).Name}\".");
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (ToStringMap.Value.TryGetValue(value, out var stringValue))
        {
            writer.WriteStringValue(stringValue);
            return;
        }

        throw new JsonException($"Unable to serialize \"{value}\" of Enum \"{typeof(T).Name}\".");
    }
}