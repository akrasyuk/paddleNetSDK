namespace PaddleBilling.Core.API.v1.Resources.BillingAndSubscriptions;

public class Totals
{
    public string Subtotal { get; set; }
    public string Tax { get; set; }
    public string Total { get; set; }
}

public class TotalsWithDiscount : Totals
{
    public string Discount { get; set; }
}

public class TransactionTotals : TotalsWithDiscount
{
    public string Credit { get; set; }
    public string CreditToBalance { get; set; }
    public string Balance { get; set; }
    public string GrandTotal { get; set; }
    public string Fee { get; set; }
    public string Earnings { get; set; }
    public string CurrencyCode { get; set; }
}



public class AdjustedTotals : Totals
{
    public string GrandTotal { get; set; }
    public string Fee { get; set; }

    public string Earnings { get; set; }

    public string CurrencyCode { get; set; }
}

public class AdjustedPayoutTotals : AdjustedTotals
{
    public ChargebackFee ChargebackFee { get; set; }
}