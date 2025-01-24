using PaddleBilling.Http.Http;

namespace PaddleBilling.Http.API.v1.QueryParams;

public abstract class BaseQueryParams
{
    protected readonly QueryParameterBuilder Builder = new();

    protected abstract void BuildQuery();

    public override string ToString()
    {
        Builder.Clear();
        BuildQuery();
        var queryString = Builder.ToString();
        return !string.IsNullOrWhiteSpace(queryString) ? $"?{queryString}" : string.Empty;
    }
}