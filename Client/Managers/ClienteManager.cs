using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;

namespace Restaurante.Client.Managers;

public interface IClienteManager
{
    Task<ResultList<ClienteRecord>> GetAsync();
}

public class ClienteManager : IClienteManager
{
    private readonly HttpClient httpClient;

    public ClienteManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<ClienteRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(ClienteRouteManager.BASE);
            var resultado = await response.ToResultList<ClienteRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<ClienteRecord>.Fail(e.Message);
        }
    }
}

