using System.Web;

namespace PaddleBilling.Http.Http;

public class QueryParameterBuilder
{
    private readonly Dictionary<string, string> _parameters = new();

    public QueryParameterBuilder Add(string key, string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            _parameters[key] = value;
        }
        return this;
    }

    public QueryParameterBuilder Add(string key, IEnumerable<string> values)
    {
        if(values == null)
        {
            return this;
        }

        var valuesList = values.ToList();

        if (valuesList.Any())
        {
            _parameters[key] = string.Join(",", valuesList);
        }
        return this;
    }

    public QueryParameterBuilder Add(string key, int? value)
    {
        if (value.HasValue)
        {
            _parameters[key] = value.Value.ToString();
        }
        return this;
    }

    public QueryParameterBuilder Add(string key, bool? value)
    {
        if (value.HasValue)
        {
            _parameters[key] = value.Value.ToString().ToLower();
        }
        return this;
    }

    public override string ToString()
    {
        var queryString = HttpUtility.ParseQueryString(string.Empty);
        foreach (var param in _parameters)
        {
            queryString[param.Key] = param.Value;
        }
        return queryString.ToString();
    }

    public void Clear()
    {
        _parameters.Clear();
    }
}