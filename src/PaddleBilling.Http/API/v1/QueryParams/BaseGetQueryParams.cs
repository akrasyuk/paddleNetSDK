namespace PaddleBilling.Http.API.v1.QueryParams;

public class BaseGetQueryParams : BaseQueryParams
{
    public ICollection<string> Include { get; set; }
    protected override void BuildQuery()
    {
        Builder
            .Add("include", Include);
    }
}