using System.Text.Json.Serialization;

namespace PaddleBilling.Http.API.v1.Requests;

public enum Status
{
    [JsonPropertyName("active")]
    Active,
    [JsonPropertyName("archived")]
    Archived
}