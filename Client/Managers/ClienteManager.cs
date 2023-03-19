using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;
using Restaurante.Shared.Requests;
using System.Net.Http.Json;

namespace Restaurante.Client.Managers;

public interface IClienteManager
{
    Task<ResultList<ClienteRecord>> GetAsync();
    Task<Result<int>> CreateAsync(ClienteCreateRequest request);
    Task<Result<ClienteRecord>> GetByIdAsync(int Id);
}

public class ClienteManager : IClienteManager
{
    private readonly HttpClient httpClient;

    public ClienteManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<ClienteRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(ClienteRouteManager.BASE);
            var resultado = await response.ToResultList<ClienteRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<ClienteRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(ClienteCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(ClienteRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<ClienteRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(ClienteRouteManager.BuildRoute(Id));
        return await response.ToResult<ClienteRecord>();
    }
}

