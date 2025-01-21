namespace PaddleBilling.Core.API.v1.Resources.Customers;

public class Customer : Entity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Locale { get; set; }
    public string Status { get; set; }
    public Dictionary<string, string> CustomData { get; set; }
    public ImportMeta ImportMeta { get; set; }
    public bool MarketingConsent { get; set; }
}