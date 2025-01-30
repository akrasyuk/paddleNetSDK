using PaddleBilling.Models.API.v1.Resources.ProductCatalog;

namespace PaddleBilling.Models.API.v1.Resources.BillingAndSubscriptions;

public class Transaction : Entity
{
    public string Status { get; set; }
    public string CustomerId { get; set; }
    public string AddressId { get; set; }
    public string BusinessId { get; set; }
    public Dictionary<string, object> CustomData { get; set; }
    public string CurrencyCode { get; set; }
    public string Origin { get; set; }
    public string SubscriptionId { get; set; }
    public string InvoiceId { get; set; }
    public string InvoiceNumber { get; set; }
    public string CollectionMode { get; set; }
    public string DiscountId { get; set; }
    public BillingDetails BillingDetails { get; set; }
    public BillingPeriod BillingPeriod { get; set; }
    public List<TransactionItem> Items { get; set; }
    public TransactionDetails Details { get; set; }
    public List<TransactionPayment> Payments { get; set; }
    public TransactionCheckout Checkout { get; set; }
    public DateTimeOffset? BilledAt { get; set; }
    public DateTimeOffset? RevisedAt { get; set; }
}

#region Supporting classes
public class TransactionItem
{
    public Price Price { get; set; }
    public int Quantity { get; set; }
    public Proration Proration { get; set; }
}

public class TransactionDetails
{
    public TaxRates TaxRatesUsed { get; set; }
    public TransactionTotals Totals { get; set; }
    public AdjustedTotals AdjustedTotals { get; set; }
    public TransactionTotals PayoutTotals { get; set; }
    public AdjustedPayoutTotals AdjustedPayoutTotals { get; set; }
    public LineItems LineItems { get; set; }
}

public class LineItems
{
    public string Id { get; set; }
    public string PriceId { get; set; }
    public int Quantity { get; set; }
    public Proration Proration { get; set; }
    public string TaxRate { get; set; }
    public TotalsWithDiscount UnitTotals { get; set; }
    public TotalsWithDiscount Totals { get; set; }
    public Product Product { get; set; }
}

public class Proration
{
    public string Rate { get; set; }
    public BillingPeriod BillingPeriod { get; set; }
}

public class TaxRates
{
    public string TaxRate { get; set; }
    public Totals Totals { get; set; }
}

public class ChargebackFee
{
    public string Amount { get; set; }

    public Original Original { get; set; }
}

public class Original
{
    public string Amount { get; set; }

    public string CurrencyCode { get; set; }
}

public class TransactionCheckout
{
    public string Url { get; set; }
}

public class TransactionPayment
{
    public string PaymentAttemptId { get; set; }
    public string StoredPaymentMethodId { get; set; }
    public string PaymentMethodId { get; set; }
    public string Amount { get; set; }
    public string Status { get; set; }
    public string ErrorCode { get; set; }
    public PaymentMethodDetails MethodDetails { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset CapturedAt { get; set; }
}

public class PaymentMethodDetails
{
    public string Type { get; set; }

    public Card Card { get; set; }
}

public class Card
{
    public string Type { get; set; }
    public string Last4 { get; set; }
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
    public string CardholderName { get; set; }
}
#endregion