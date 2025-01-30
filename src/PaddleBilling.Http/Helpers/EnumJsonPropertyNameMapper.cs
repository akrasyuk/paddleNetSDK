using System.Collections.Concurrent;
using System.Reflection;
using System.Text.Json.Serialization;

namespace PaddleBilling.Http.Helpers;

public static class EnumJsonPropertyNameMapper
{
    private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, object>> EnumValueCache = new();

    public static TEnum GetValueFromJsonPropertyName<TEnum>(string jsonPropertyName) where TEnum : struct, Enum
    {
        var enumType = typeof(TEnum);

        // Get or populate the cache for the enum type
        var nameToValueMap = EnumValueCache.GetOrAdd(enumType, _ =>
        {
            var map = new ConcurrentDictionary<string, object>();
            foreach (var field in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attribute = field.GetCustomAttribute<JsonPropertyNameAttribute>();
                var name = attribute?.Name ?? field.Name;
                var enumValue = field.GetValue(null);
                map.TryAdd(name, enumValue);
            }
            return map;
        });

        // Lookup the enum value
        if (nameToValueMap.TryGetValue(jsonPropertyName, out var value))
        {
            return (TEnum)value;
        }

        throw new ArgumentException($"No matching enum value for JSON property name '{jsonPropertyName}' in enum '{enumType.Name}'.");
    }
}