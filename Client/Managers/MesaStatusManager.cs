using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;

namespace Restaurante.Client.Managers;

public interface IMesaStatusManager
{
    Task<ResultList<MesaStatusRecord>> GetAsync();
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
}
