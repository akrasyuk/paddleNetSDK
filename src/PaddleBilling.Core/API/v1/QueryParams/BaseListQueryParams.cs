namespace PaddleBilling.Core.API.v1.QueryParams;

public class BaseListQueryParams : BaseQueryParams
{

    public string After { get; set; }
    public IEnumerable<string> Ids { get; set; }
    public IEnumerable<string> Include { get; set; }
    public string OrderBy { get; set; }
    public int? PerPage { get; set; }
    public IEnumerable<string> Status { get; set; }
    public string Type { get; set; }


    protected override void BuildQuery()
    {
        Builder
            .Add("after", After)
            .Add("id", Ids)
            .Add("include", Include)
            .Add("order_by", OrderBy)
            .Add("per_page", PerPage)
            .Add("status", Status)
            .Add("type", Type);
    }
}