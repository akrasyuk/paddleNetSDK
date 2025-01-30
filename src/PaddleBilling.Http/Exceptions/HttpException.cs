using System.Net;

namespace PaddleBilling.Http.Exceptions;

public class HttpException : Exception
{
    public HttpStatusCode? ResponseStatusCode { get; set; }

    public HttpException(string message, HttpStatusCode responseStatusCode)
        : base(message)
    {
        ResponseStatusCode = responseStatusCode;
    }

    public HttpException(string message, Exception innerException)
        : base(message, innerException)
    {
        if (innerException is HttpRequestException httpRequestException)
        {
            ResponseStatusCode = httpRequestException.InnerException is WebException { Response: HttpWebResponse httpWebResponse }
                ? httpWebResponse.StatusCode
                : httpRequestException.StatusCode;
        }
    }
}