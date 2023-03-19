using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;
using Restaurante.Shared.Requests;
using System.Net.Http.Json;

namespace Restaurante.Client.Managers;

public interface IAsignacionMesaManager
{
    Task<ResultList<AsignacionMesaRecord>> GetAsync();
    Task<Result<int>> CreateAsync(AsignacionMesaCreateRequest request);
    Task<Result<AsignacionMesaRecord>> GetByIdAsync(int Id);
}

public class AsignacionMesaManager : IAsignacionMesaManager
{
    private readonly HttpClient httpClient;

    public AsignacionMesaManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<AsignacionMesaRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(AsignacionMesaRouteManager.BASE);
            var resultado = await response.ToResultList<AsignacionMesaRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<AsignacionMesaRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(AsignacionMesaCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(AsignacionMesaRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<AsignacionMesaRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(AsignacionMesaRouteManager.BuildRoute(Id));
        return await response.ToResult<AsignacionMesaRecord>();
    }
}
