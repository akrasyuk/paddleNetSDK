using System.Text.Json.Serialization;
using PaddleBilling.Models.API.v1.Resources;
using PaddleBilling.Models.API.v1.Resources.Enums;
using PaddleBilling.Models.API.v1.Resources.ProductCatalog;

namespace PaddleBilling.Http.API.v1.Requests.Prices;

public class PatchPriceRequest
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

    [JsonPropertyName("billing_cycle")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BillingCycle BillingCycle { get; private set; }

    [JsonPropertyName("trial_period")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TrialPeriod TrialPeriod { get; private set; }

    [JsonPropertyName("tax_mode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string TaxMode { get; private set; }

    [JsonPropertyName("unit_price")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public UnitPrice UnitPrice { get; private set; }

    [JsonPropertyName("unit_price_overrides")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<UnitPriceOverride> UnitPriceOverrides { get; private set; }

    [JsonPropertyName("quantity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Quantity Quantity { get; private set; }

    [JsonPropertyName("custom_data")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object> CustomData { get; private set; }

    [JsonPropertyName("status")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Status? Status { get; private set; }

    protected PatchPriceRequest()
    {
    }

    public class Builder
    {
        private readonly PatchPriceRequest _request = new();

        public Builder WithName(string name)
        {
            _request.Name = name;
            return this;
        }

        public Builder WithDescription(string description)
        {
            _request.Description = description;
            return this;
        }

        public Builder WithType(ItemType type)
        {
            _request.Type = type;
            return this;
        }

        public Builder WithBillingCycle(BillingCycle billingCycle)
        {
            _request.BillingCycle = billingCycle;
            return this;
        }

        public Builder WithTrialPeriod(TrialPeriod trialPeriod)
        {
            _request.TrialPeriod = trialPeriod;
            return this;
        }

        public Builder WithTaxMode(string taxMode)
        {
            _request.TaxMode = taxMode;
            return this;
        }

        public Builder WithUnitPrice(UnitPrice unitPrice)
        {
            _request.UnitPrice = unitPrice;
            return this;
        }

        public Builder WithUnitPriceOverrides(IEnumerable<UnitPriceOverride> unitPriceOverrides)
        {
            _request.UnitPriceOverrides = unitPriceOverrides;
            return this;
        }

        public Builder WithQuantity(Quantity quantity)
        {
            _request.Quantity = quantity;
            return this;
        }

        public Builder WithCustomData(Dictionary<string, object> customData)
        {
            _request.CustomData = customData;
            return this;
        }

        public Builder WithStatus(Status status)
        {
            _request.Status = status;
            return this;
        }

        public PatchPriceRequest Build()
        {
            return _request;
        }
    }
}