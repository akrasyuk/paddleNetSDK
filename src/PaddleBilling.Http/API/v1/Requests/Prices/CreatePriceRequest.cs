using PaddleBilling.Models.API.v1.Resources;
using PaddleBilling.Models.API.v1.Resources.ProductCatalog;

namespace PaddleBilling.Http.API.v1.Requests.Prices;

public class CreatePriceRequest
{
    public string Description { get; private set; }
    public string ProductId { get; private set; }
    public UnitPrice UnitPrice { get; private set; }
    public string Type { get; private set; }
    public string Name { get; private set; }
    public BillingCycle BillingCycle { get; private set; }
    public TrialPeriod TrialPeriod { get; private set; }
    public string TaxMode { get; private set; }
    public IEnumerable<UnitPriceOverride> UnitPriceOverrides { get; private set; }
    public Quantity Quantity { get; private set; }
    public Dictionary<string, object> CustomData { get; private set; }

    protected CreatePriceRequest(string description, string productId, UnitPrice unitPrice)
    {
        Description = description;
        ProductId = productId;
        UnitPrice = unitPrice;
    }

    public class Builder
    {
        private readonly CreatePriceRequest _request;

        public Builder(string description, string productId, UnitPrice unitPrice)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty", nameof(description));
            if (string.IsNullOrWhiteSpace(productId))
                throw new ArgumentException("ProductId cannot be null or empty", nameof(productId));
            ValidateUnitPrice(unitPrice);

            _request = new CreatePriceRequest(description, productId, unitPrice);
        }

        private static void ValidateUnitPrice(UnitPrice unitPrice)
        {
            if (unitPrice == null) throw new ArgumentNullException(nameof(unitPrice));
            if (string.IsNullOrWhiteSpace(unitPrice.Amount)) throw new ArgumentException("Amount cannot be null or empty", nameof(unitPrice.Amount));
            if (string.IsNullOrWhiteSpace(unitPrice.CurrencyCode)) throw new ArgumentException("CurrencyCode cannot be null or empty", nameof(unitPrice.CurrencyCode));
        }

        public Builder WithType(string type)
        {
            _request.Type = type;
            return this;
        }

        public Builder WithName(string name)
        {
            _request.Name = name;
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

        public Builder WithTaxMode(string taxMode)
        {
            _request.TaxMode = taxMode;
            return this;
        }

        public CreatePriceRequest Build()
        {
            return _request;
        }
    }
}