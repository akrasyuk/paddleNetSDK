namespace PaddleBilling.Core.API.v1.Resources.BillingAndSubscriptions;

// Base class for Subscription Events
public class Subscription : Entity
{
    public List<SubscriptionItem> Items { get; set; }
    public string Status { get; set; }
    public DiscountInfo Discount { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? PausedAt { get; set; }
    public string AddressId { get; set; }
    public string BusinessId { get; set; }
    public string CustomerId { get; set; }
    public string TransactionId { get; set; }
    public DateTime? CanceledAt { get; set; }
    public BillingCycle BillingCycle { get; set; }
    public string CurrencyCode { get; set; }
    public DateTime? NextBilledAt { get; set; }
    public string CollectionMode { get; set; }
    public BillingDetails BillingDetails { get; set; }
    public DateTime? FirstBilledAt { get; set; }
    public BillingPeriod CurrentBillingPeriod { get; set; }
    public ImportMeta ImportMeta { get; set; }
    public Dictionary<string, string> CustomData { get; set; }
    public ScheduledChange ScheduledChange { get; set; }
}

#region Supporting classes
public class SubscriptionItem
{
    public PriceDetails Price { get; set; }
    public ProductDetails Product { get; set; }
    public string Status { get; set; }
    public int Quantity { get; set; }
    public bool Recurring { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public TrialDates TrialDates { get; set; }
    public DateTimeOffset? NextBilledAt { get; set; }
    public DateTimeOffset? PreviouslyBilledAt { get; set; }
}

public class PriceDetails
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public QuantityRange Quantity { get; set; }
    public string TaxMode { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string ProductId { get; set; }
    public UnitPrice UnitPrice { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Dictionary<string, string> CustomData { get; set; }
    public string Description { get; set; }
    public ImportMeta ImportMeta { get; set; }
    public TrialPeriod TrialPeriod { get; set; }
    public BillingCycle BillingCycle { get; set; }
    public List<UnitPriceOverride> UnitPriceOverrides { get; set; }
}

public class ProductDetails
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string TaxCategory { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public Dictionary<string, string> CustomData { get; set; }
    public string Status { get; set; }
    public ImportMeta ImportMeta { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}

public class QuantityRange
{
    public int Maximum { get; set; }
    public int Minimum { get; set; }
}

public class TrialDates
{
    public DateTimeOffset StartsAt { get; set; }
    public DateTimeOffset EndsAt { get; set; }
}

public class DiscountInfo
{
    public DateTimeOffset? EndsAt { get; set; }
    public string Id { get; set; }
    public DateTimeOffset? StartsAt { get; set; }
}

public class ScheduledChange
{
    public string Action { get; set; }
    public DateTimeOffset EffectiveAt { get; set; }
    public DateTimeOffset ResumeAt { get; set; }
}
#endregion