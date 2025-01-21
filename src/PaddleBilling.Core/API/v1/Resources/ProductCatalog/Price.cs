namespace PaddleBilling.Core.API.v1.Resources.ProductCatalog;

public class Price : Entity
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public Quantity Quantity { get; set; }
    public string TaxMode { get; set; }
    public string ProductId { get; set; }
    public UnitPrice UnitPrice { get; set; }
    public Dictionary<string, string> CustomData { get; set; }
    public string Description { get; set; }
    public ImportMeta ImportMeta { get; set; }
    public TrialPeriod TrialPeriod { get; set; }
    public BillingCycle BillingCycle { get; set; }
    public List<UnitPriceOverride> UnitPriceOverrides { get; set; }
}

#region Supporting classes

public class Quantity
{
    public int Maximum { get; set; }
    public int Minimum { get; set; }
}

#endregion