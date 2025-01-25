using PaddleBilling.Models.API.v1.Resources.Enums;

namespace PaddleBilling.Models.API.v1.Resources.ProductCatalog;

public class Product : Entity
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public string ImageUrl { get; set; }
    public Dictionary<string, object> CustomData { get; set; }
    public string Description { get; set; }
    public ImportMeta ImportMeta { get; set; }
    public TaxCategory TaxCategory { get; set; }
}