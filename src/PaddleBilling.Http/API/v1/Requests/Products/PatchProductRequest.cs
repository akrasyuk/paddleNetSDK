using System.Text.Json.Serialization;
using PaddleBilling.Models.API.v1.Resources.Enums;

namespace PaddleBilling.Http.API.v1.Requests.Products;

public class PatchProductRequest
{
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; private set; }

    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Description { get; private set; }

    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ItemType? Type { get; private set; }

    [JsonPropertyName("tax_category")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TaxCategory? TaxCategory { get; private set; }

    [JsonPropertyName("image_url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ImageUrl { get; private set; }

    [JsonPropertyName("custom_data")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object> CustomData { get; private set; }

    [JsonPropertyName("status")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Status? Status { get; private set; }

    protected PatchProductRequest()
    {
    }

    public class Builder
    {
        private readonly PatchProductRequest _request = new();

        public Builder SetName(string name)
        {
            _request.Name = name;
            return this;
        }

        public Builder SetDescription(string description)
        {
            _request.Description = description;
            return this;
        }

        public Builder SetType(ItemType type)
        {
            _request.Type = type;
            return this;
        }

        public Builder SetTaxCategory(TaxCategory taxCategory)
        {
            _request.TaxCategory = taxCategory;
            return this;
        }

        public Builder SetImageUrl(string imageUrl)
        {
            _request.ImageUrl = imageUrl;
            return this;
        }

        public Builder SetCustomData(Dictionary<string, object> CustomData)
        {
            _request.CustomData = customData;
            return this;
        }

        public Builder SetStatus(Status status)
        {
            _request.Status = status;
            return this;
        }

        public PatchProductRequest Build()
        {
            return _request;
        }
    }
}