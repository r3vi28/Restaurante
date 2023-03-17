using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;

namespace Restaurante.Client.Managers;

public interface IPedidoManager
{
    Task<ResultList<PedidoRecord>> GetAsync();
}

public class PedidoManager : IPedidoManager
{
    private readonly HttpClient httpClient;

    public PedidoManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<PedidoRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(PedidoRouteManager.BASE);
            var resultado = await response.ToResultList<PedidoRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<PedidoRecord>.Fail(e.Message);
        }
    }
}
