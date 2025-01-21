namespace PaddleBilling.Core.API.v1.Resources;

public class Report : Entity
{
    public int? Rows { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public List<Filter> Filters { get; set; }
    public DateTimeOffset? ExpiresAt { get; set; }
}

#region Supporting Classes

public class Filter
{
    public string Name { get; set; }
    public object Value { get; set; }
    public string Operator { get; set; }
}

#endregion