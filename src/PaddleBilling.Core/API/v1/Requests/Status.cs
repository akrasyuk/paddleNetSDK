using System.Text.Json.Serialization;

namespace PaddleBilling.Core.API.v1.Requests;

public enum Status
{
    [JsonPropertyName("active")]
    Active,
    [JsonPropertyName("archived")]
    Archived
}