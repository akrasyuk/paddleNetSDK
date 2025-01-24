namespace PaddleBilling.Models.API.v1.Resources;

public class Payout : Entity
{
    public string Status { get; set; }
    public string Amount { get; set; }
    public string CurrencyCode { get; set; }
}