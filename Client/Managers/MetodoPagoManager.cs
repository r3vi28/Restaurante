using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;
using Restaurante.Shared.Requests;
using System.Net.Http.Json;

namespace Restaurante.Client.Managers;

public interface IMetodoPagoManager
{
    Task<ResultList<MetodoPagoRecord>> GetAsync();
    Task<Result<int>> CreateAsync(MetodoPagoCreateRequest request);
}

public class MetodoPagoManager : IMetodoPagoManager
{
    private readonly HttpClient httpClient;

    public MetodoPagoManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<MetodoPagoRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(MetodoPagoRouteManager.BASE);
            var resultado = await response.ToResultList<MetodoPagoRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<MetodoPagoRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(MetodoPagoCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(MetodoPagoRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
}
