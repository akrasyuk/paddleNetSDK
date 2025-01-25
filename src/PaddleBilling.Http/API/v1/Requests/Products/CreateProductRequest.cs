using PaddleBilling.Models.API.v1.Resources.Enums;

namespace PaddleBilling.Http.API.v1.Requests.Products;

public class CreateProductRequest
{
    protected CreateProductRequest(
        string name,
        TaxCategory taxCategory)
    {
        Name = name;
        TaxCategory = taxCategory;
    }

    public string Name { get; private set; }

    public TaxCategory TaxCategory { get; private set; }

    public string Description { get; private set; }

    public ItemType Type { get; private set; }

    public Uri ImageUrl { get; private set; }

    public Dictionary<string, object> CustomData { get; private set; }

    public class Builder
    {
        private readonly CreateProductRequest _request;

        public Builder(string name, TaxCategory taxCategory)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty", nameof(name));

            _request = new CreateProductRequest(name, taxCategory);
        }

        public Builder WithDescription(string description)
        {
            _request.Description = description;
            return this;
        }

        public Builder WithType(ItemType type)
        {
            _request.Type = type;
            return this;
        }

        public Builder WithImageUrl(Uri imageUrl)
        {
            _request.ImageUrl = imageUrl;
            return this;
        }

        public Builder WithCustomData(Dictionary<string, object> customData)
        {
            _request.CustomData = customData;
            return this;
        }

        public CreateProductRequest Build()
        {
            return _request;
        }
    }
}

