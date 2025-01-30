namespace PaddleBilling.Http.API.v1.QueryParams.Prices;

public class ListPricesQueryParams : BaseListQueryParams
{
    public IEnumerable<string> ProductId { get; set; }
    public bool? Recurring { get; set; }


    protected override void BuildQuery()
    {
        base.BuildQuery();

        Builder
            .Add("recurring", Recurring)
            .Add("product_id", ProductId);
    }
}