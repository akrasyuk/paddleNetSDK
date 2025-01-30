namespace PaddleBilling.Models.API.v1.Resources.Customers;

public class Business : Entity
{
    public string Name { get; set; }
    public string Status { get; set; }
    public List<Contact> Contacts { get; set; }
    public Dictionary<string, object> CustomData { get; set; }
    public string CustomerId { get; set; }
    public string CompanyNumber { get; set; }
    public string TaxIdentifier { get; set; }
    public ImportMeta ImportMeta { get; set; }
}

#region Supporting classes

public class Contact
{
    public string Name { get; set; }
    public string Email { get; set; }
}

#endregion