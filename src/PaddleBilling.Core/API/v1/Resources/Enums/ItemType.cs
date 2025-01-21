using PaddleBilling.Core.Converters;
using System.Text.Json.Serialization;

namespace PaddleBilling.Core.API.v1.Resources.Enums;

[JsonConverter(typeof(BidirectionalJsonStringEnumConverter<ItemType>))]
public enum ItemType
{
    [JsonPropertyName("standard")]
    Standard,
    [JsonPropertyName("custom")]
    Custom
}