namespace PaddleBilling.Models.API.v1.Resources.Customers;

public class Address : Entity
{
    public string City { get; set; }
    public string Region { get; set; }
    public string Status { get; set; }
    public string FirstLine { get; set; }
    public Dictionary<string, string> CustomData { get; set; }
    public string CustomerId { get; set; }
    public string Description { get; set; }
    public ImportMeta ImportMeta { get; set; }
    public string SecondLine { get; set; }
    public string PostalCode { get; set; }
    public string CountryCode { get; set; }
}