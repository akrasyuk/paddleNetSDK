using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using PaddleBilling.Http.Exceptions;

namespace PaddleBilling.Http.Http;

public abstract class BaseClient(
    ILogger logger,
    HttpClient client)
{
    protected readonly string _clientName;
    private const string AuthScheme = "Bearer";

    protected async Task<TOut> GetAsync<TOut>(
        string route,
        string accessToken)
    {
        return await SendHttpRequestAsync<object, TOut>(
            HttpMethod.Get,
            route,
            null,
            accessToken);
    }

    protected async Task<HttpResponseMessage> PostAsync<TIn>(
        TIn request,
        string route,
        string accessToken)
    {
        return await SendHttpRequestAsync<TIn, HttpResponseMessage>(
            HttpMethod.Post,
            route,
            request,
            accessToken);
    }

    protected async Task<TOut> PostAsync<TIn, TOut>(
        TIn request,
        string route,
        string accessToken = null)
    {
        return await SendHttpRequestAsync<TIn, TOut>(
            HttpMethod.Post,
            route,
            request,
            accessToken);
    }

    protected async Task<TOut> PatchAsync<TIn, TOut>(
        TIn request,
        string route,
        string accessToken)
    {
        return await SendHttpRequestAsync<TIn, TOut>(
            HttpMethod.Patch, 
            route,
            request,
            accessToken);
    }

    protected async Task<TOut> PutAsync<TOut>(
        string route,
        string accessToken) where TOut : class, new()
    {
        return await SendHttpRequestAsync<object, TOut>(
            HttpMethod.Put,
            route,
            null,
            accessToken);
    }

    protected async Task<TOut> PutAsync<TIn, TOut>(
        TIn request,
        string route,
        string accessToken)
    {
        return await SendHttpRequestAsync<TIn, TOut>(
            HttpMethod.Put,
            route,
            request,
            accessToken);
    }

    private async Task<TOut> SendHttpRequestAsync<TIn, TOut>(
        HttpMethod method,
        string route,
        TIn request,
        string accessToken)
    {
        var content = CreateHttpRequest(method, request);

        var response = await SendHttpRequestAsync(method, route, accessToken, content);

        return await GenerateResponseAsync<TOut>(method, route, response);
    }

    private const string ErrorDuringHttpRequest =
        "Error during Http Request {HttpMethod} {Route} with Message: {ErrorMessage}";

    private async Task<HttpResponseMessage> SendHttpRequestAsync(
        HttpMethod method,
        string route,
        string accessToken = null,
        HttpContent content = null)
    {
        HttpResponseMessage response;

        try
        {
            var httpRequestMessage = new HttpRequestMessage(method, route)
            {
                Content = content
            };

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(AuthScheme, accessToken);
            }

            response = await client.SendAsync(httpRequestMessage);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ErrorDuringHttpRequest, method.Method, route, ex.Message);

            throw new HttpException($"Error during Http Request {method.Method} {route} with Message: {ex.Message}",
                ex);
        }

        if (!response.IsSuccessStatusCode)
        {
            var serverErrorMessage = await response.Content.ReadAsStringAsync();
            var logMessage = string.IsNullOrWhiteSpace(serverErrorMessage) ? response.ReasonPhrase : serverErrorMessage;

            logger.LogError(ErrorDuringHttpRequest, method.Method, route, logMessage);
            throw new HttpException(
                $"Error during Http Request {method.Method} {route} with Message: Server returned error response",
                response.StatusCode);
        }

        return response;
    }

    private StringContent CreateHttpRequest<TIn>(HttpMethod method, TIn request)
    {
        if (request is null || method == HttpMethod.Get)
        {
            return null;
        }

        var json = JsonSerializer.Serialize(request, Defaults.DefaultJsonSerializerOptions);

        return new StringContent(json,
            Encoding.UTF8, "application/json");
    }

    private const string ErrorDuringResponseDeserialization =
        "Error during Http Request {HttpMethod} {Route}. Failed to deserialize response body with Message: {ErrorMessage}";

    private async Task<TOut> GenerateResponseAsync<TOut>(HttpMethod method, string route, HttpResponseMessage response)
    {
        if (response is TOut httpResponse)
        {
            return httpResponse;
        }

        try
        {
#if DEBUG
            var json = await response.Content.ReadAsStringAsync();
            logger.LogInformation("Response Body: {Json}", json);
#endif
            return await response.Content.ReadFromJsonAsync<TOut>(Defaults.DefaultJsonSerializerOptions);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ErrorDuringResponseDeserialization, method.Method, route, ex.Message);

            throw new HttpException(
                $"Error during Http Request {method.Method} {route}. Failed to deserialize response body with Message: {ex.Message}",
                ex);
        }
    }
}