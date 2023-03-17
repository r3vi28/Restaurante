using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;

namespace Restaurante.Client.Managers;

public interface IProductoManager
{
    Task<ResultList<ProductoRecord>> GetAsync();
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
}
