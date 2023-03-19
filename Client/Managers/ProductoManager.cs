using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;
using Restaurante.Shared.Requests;
using System.Net.Http.Json;

namespace Restaurante.Client.Managers;

public interface IProductoManager
{
    Task<ResultList<ProductoRecord>> GetAsync();
    Task<Result<int>> CreateAsync(ProductoCreateRequest request);
}

public class ProductoManager : IProductoManager
{
    private readonly HttpClient httpClient;

    public ProductoManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<ProductoRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(ProductoRouteManager.BASE);
            var resultado = await response.ToResultList<ProductoRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<ProductoRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(ProductoCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(ProductoRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
}
