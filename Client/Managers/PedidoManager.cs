using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;
using Restaurante.Shared.Requests;
using System.Net.Http.Json;

namespace Restaurante.Client.Managers;

public interface IPedidoManager
{
    Task<ResultList<PedidoRecord>> GetAsync();
    Task<Result<int>> CreateAsync(PedidoCreateRequest request);
}

public class PedidoManager : IPedidoManager
{
    private readonly HttpClient httpClient;

    public PedidoManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<PedidoRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(PedidoRouteManager.BASE);
            var resultado = await response.ToResultList<PedidoRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<PedidoRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(PedidoCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(PedidoRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
}
