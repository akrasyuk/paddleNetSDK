namespace PaddleBilling.Core.API.v1.Resources.ProductCatalog;

public class Discount : Entity
{
    public string Code { get; set; }
    public string Type { get; set; }
    public bool Recur { get; set; }
    public string Amount { get; set; }
    public string Status { get; set; }
    public DateTimeOffset? ExpiresAt { get; set; }
    public Dictionary<string, string> CustomData { get; set; }
    public string Description { get; set; }
    public ImportMeta ImportMeta { get; set; }
    public List<string> RestrictTo { get; set; }
    public int? UsageLimit { get; set; }
    public string CurrencyCode { get; set; }
    public bool EnabledForCheckout { get; set; }
    public int? MaximumRecurringIntervals { get; set; }
}