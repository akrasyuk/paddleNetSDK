namespace PaddleBilling.Http.API.v1.QueryParams.NotificationSettings;

public class ListNotificationSettingsQueryParams : BaseQueryParams
{
    public string After { get; set; }
    public int PerPage { get; set; }
    public string OrderBy { get; set; }
    public bool Active { get; set; }
    public string TrafficSource { get; set; }
    protected override void BuildQuery()
    {
        Builder
            .Add("after", After)
            .Add("per_page", PerPage)
            .Add("order_by", OrderBy)
            .Add("active", Active)
            .Add("traffic_source", TrafficSource);
    }
}