using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;

namespace Restaurante.Client.Managers;

public interface IAsignacionMesaManager
{
    Task<ResultList<AsignacionMesaRecord>> GetAsync();
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
}
