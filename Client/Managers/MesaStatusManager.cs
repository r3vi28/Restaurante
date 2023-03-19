using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;
using Restaurante.Shared.Requests;
using System.Net.Http.Json;

namespace Restaurante.Client.Managers;

public interface IMesaStatusManager
{
    Task<ResultList<MesaStatusRecord>> GetAsync();
    Task<Result<int>> CreateAsync(MesaStatusCreateRequest request);
}

public class MesaStatusManager : IMesaStatusManager
{
    private readonly HttpClient httpClient;

    public MesaStatusManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<MesaStatusRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(MesaStatusRouteManager.BASE);
            var resultado = await response.ToResultList<MesaStatusRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<MesaStatusRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(MesaStatusCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(MesaStatusRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
}
