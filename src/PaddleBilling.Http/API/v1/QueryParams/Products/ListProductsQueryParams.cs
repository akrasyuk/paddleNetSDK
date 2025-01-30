namespace PaddleBilling.Http.API.v1.QueryParams.Products;

public class ListProductsQueryParams : BaseListQueryParams
{
    public IEnumerable<string> TaxCategory { get; set; }

    protected override void BuildQuery()
    {
        base.BuildQuery();

        Builder
            .Add("tax_category", TaxCategory);
    }
}