using Microsoft.Extensions.Logging;
using PaddleBilling.Core.API.v1.QueryParams.Prices;
using PaddleBilling.Core.API.v1.QueryParams.Products;
using PaddleBilling.Core.API.v1.Requests.Prices;
using PaddleBilling.Core.API.v1.Requests.Products;
using PaddleBilling.Core.API.v1.Resources;
using PaddleBilling.Core.API.v1.Resources.ProductCatalog;
using PaddleBilling.Core.Http;
using PaddleBilling.Core.Options;

namespace PaddleBilling.Core.API.v1;

public class PaddleClient(
    ILogger<PaddleClient> logger,
    HttpClient client,
    PaddleClientOptions options)
    : BaseClient(logger, client)
{

    private string ApiKey => options.ApiKey;

    public async Task<bool> TestConnectionAsync()
    {
        var response = await GetAsync<EventTypes>("/event-types", options.ApiKey);

        return response?.Data?.Count > 0;
    }

    #region Products

    private const string ProductsRoute = "/products";

    public async Task<PaddleResponseForCollection<Product>> GetProductsAsync(ListProductsQueryParams queryParams = null)
    {
        var route = queryParams == null
            ? ProductsRoute
            : $"{ProductsRoute}{queryParams}";

        return await GetAsync<PaddleResponseForCollection<Product>>(route, ApiKey);
    }

    public async Task<PaddleResponseForEntity<Product>> GetProductAsync(string productId, GetProductQueryParams queryParams = null)
    {
        var route = queryParams == null
            ? $"{ProductsRoute}/{productId}"
            : $"{ProductsRoute}/{productId}{queryParams}";

        return await GetAsync<PaddleResponseForEntity<Product>>(route, ApiKey);
    }

    public async Task<PaddleResponseForEntity<Product>> CreateProductAsync(CreateProductRequest request)
    {
        return await PostAsync<CreateProductRequest, PaddleResponseForEntity<Product>>(request, ProductsRoute, ApiKey);
    }

    public async Task<PaddleResponseForEntity<Product>> PatchProductAsync(string productId, PatchProductRequest request)
    {
        return await PatchAsync<PatchProductRequest, PaddleResponseForEntity<Product>>(request,
            $"{ProductsRoute}/{productId}",
            ApiKey);
    }


    #endregion

    #region Prices

    private const string PricesRoute = "/prices";

    public async Task<PaddleResponseForCollection<Price>> GetPricesAsync(ListPricesQueryParams queryParams = null)
    {
        var route = queryParams == null
            ? PricesRoute
            : $"{PricesRoute}{queryParams}";

        return await GetAsync<PaddleResponseForCollection<Price>>(route, ApiKey);
    }

    public async Task<PaddleResponseForEntity<Price>> GetPriceAsync(string priceId, GetPriceQueryParams queryParams = null)
    {
        return await GetAsync<PaddleResponseForEntity<Price>>($"{PricesRoute}/{priceId}", ApiKey);
    }

    public async Task<PaddleResponseForEntity<Price>> CreatePriceAsync(CreatePriceRequest request)
    {
        return await PostAsync<CreatePriceRequest, PaddleResponseForEntity<Price>>(request, PricesRoute, ApiKey);
    }

    public async Task<PaddleResponseForEntity<Price>> PatchPriceAsync(string priceId, PatchPriceRequest request)
    {
        return await PatchAsync<PatchPriceRequest, PaddleResponseForEntity<Price>>(request,
            $"{PricesRoute}/{priceId}",
            ApiKey);
    }

    #endregion

}