using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;

namespace Restaurante.Client.Managers;

public interface IReporteManager
{
    Task<ResultList<ReporteRecord>> GetAsync();
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
}
