namespace PaddleBilling.Core.API.v1.Resources;

public class ImportMeta
{
    public string ExternalId { get; set; }
    public string ImportedFrom { get; set; }
}

public class UnitPrice
{
    /// <summary>
    /// Amount in the lowest denomination for the currency, e.g. 10 USD = 1000 (cents).
    /// Although represented as a string, this value must be a valid integer.
    /// </summary>
    public string Amount { get; set; }
    public string CurrencyCode { get; set; }
}

public class TrialPeriod
{
    public string Interval { get; set; }
    public int Frequency { get; set; }
}

public class BillingCycle
{
    public string Interval { get; set; }
    public int Frequency { get; set; }
}

public class UnitPriceOverride
{
    public UnitPrice UnitPrice { get; set; }
    public List<string> CountryCodes { get; set; }
}

public class BillingPeriod
{
    public DateTimeOffset StartsAt { get; set; }
    public DateTimeOffset EndsAt { get; set; }
}

public class PaymentTerms
{
    public string Interval { get; set; }
    public int Frequency { get; set; }
}

public class BillingDetails
{
    public PaymentTerms PaymentTerms { get; set; }
    public bool EnableCheckout { get; set; }
    public int PurchaseOrderNumber { get; set; }
    public string AdditionalInformation { get; set; }
}