using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;

namespace Restaurante.Client.Managers;

public interface IMetodoPagoManager
{
    Task<ResultList<MetodoPagoRecord>> GetAsync();
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
}
