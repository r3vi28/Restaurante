using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;
using Restaurante.Shared.Requests;
using System.Net.Http.Json;

namespace Restaurante.Client.Managers;

public interface IPedidoStatusManager
{
    Task<ResultList<PedidoStatusRecord>> GetAsync();
    Task<Result<int>> CreateAsync(PedidoStatusCreateRequest request);
}

public class PedidoStatusManager : IPedidoStatusManager
{
    private readonly HttpClient httpClient;

    public PedidoStatusManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<PedidoStatusRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(PedidoStatusRouteManager.BASE);
            var resultado = await response.ToResultList<PedidoStatusRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<PedidoStatusRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(PedidoStatusCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(PedidoStatusRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
}
