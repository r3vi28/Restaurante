using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;
using Restaurante.Shared.Requests;
using System.Net.Http.Json;

namespace Restaurante.Client.Managers;

public interface IReporteManager
{
    Task<ResultList<ReporteRecord>> GetAsync();
    Task<Result<int>> CreateAsync(ReporteCreateRequest request);
}

public class ReporteManager : IReporteManager
{
    private readonly HttpClient httpClient;

    public ReporteManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<ReporteRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(ReporteRouteManager.BASE);
            var resultado = await response.ToResultList<ReporteRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<ReporteRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(ReporteCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(ReporteRouteManager.BASE,request);
        return await response.ToResult<int>();
    }
}
