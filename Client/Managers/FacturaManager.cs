using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;

namespace Restaurante.Client.Managers;

public interface IFacturaManager
{
    Task<ResultList<FacturaRecord>> GetAsync();
}

public class FacturaManager : IFacturaManager
{
    private readonly HttpClient httpClient;

    public FacturaManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<FacturaRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(FacturaRouteManager.BASE);
            var resultado = await response.ToResultList<FacturaRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<FacturaRecord>.Fail(e.Message);
        }
    }
}

