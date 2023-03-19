using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;
using Restaurante.Shared.Requests;
using System.Net.Http.Json;

namespace Restaurante.Client.Managers;

public interface IMesaManager
{
    Task<ResultList<MesaRecord>> GetAsync();
    Task<Result<int>> CreateAsync(MesaCreateRequest request);
}

public class MesaManager : IMesaManager
{
    private readonly HttpClient httpClient;

    public MesaManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<MesaRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(MesaRouteManager.BASE);
            var resultado = await response.ToResultList<MesaRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<MesaRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(MesaCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(MesaRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
}