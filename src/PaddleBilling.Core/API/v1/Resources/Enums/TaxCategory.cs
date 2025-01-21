using PaddleBilling.Core.Converters;
using System.Text.Json.Serialization;

namespace PaddleBilling.Core.API.v1.Resources.Enums;

[JsonConverter(typeof(BidirectionalJsonStringEnumConverter<TaxCategory>))]
public enum TaxCategory
{
    [JsonPropertyName("digital-goods")]
    DigitalGoods,

    [JsonPropertyName("ebooks")]
    Ebooks,

    [JsonPropertyName("implementation-services")]
    ImplementationServices,

    [JsonPropertyName("professional-services")]
    ProfessionalServices,

    [JsonPropertyName("saas")]
    Saas,

    [JsonPropertyName("software-programming-services")]
    SoftwareProgrammingServices,

    [JsonPropertyName("standard")]
    Standard,

    [JsonPropertyName("training-services")]
    TrainingServices,

    [JsonPropertyName("website-hosting")]
    WebsiteHosting
}