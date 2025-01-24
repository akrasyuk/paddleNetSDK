namespace PaddleBilling.Models.API.v1.Resources.BillingAndSubscriptions;

public class Adjustment : Entity
{
    public List<AdjustmentItem> Items { get; set; }
    public string Action { get; set; }
    public string Type { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; }
    public AdjustmentTotals Totals { get; set; }
    public string CustomerId { get; set; }
    public string CurrencyCode { get; set; }
    public AdjustmentTotals PayoutTotals { get; set; }
    public string TransactionId { get; set; }
    public string SubscriptionId { get; set; }
    public string CreditAppliedToBalance { get; set; }
}

#region Supporting classes

public class AdjustmentItem
{
    public string Id { get; set; }
    public string Type { get; set; }
    public string Amount { get; set; }
    public AdjustmentItemTotals Totals { get; set; }
    public string ItemId { get; set; }
    public string Proration { get; set; }
}

public class AdjustmentItemTotals
{
    public string Tax { get; set; }
    public string Total { get; set; }
    public string Subtotal { get; set; }
}

public class AdjustmentTotals
{
    public string Fee { get; set; }
    public string Tax { get; set; }
    public string Total { get; set; }
    public string Earnings { get; set; }
    public string Subtotal { get; set; }
    public string CurrencyCode { get; set; }
}

#endregion