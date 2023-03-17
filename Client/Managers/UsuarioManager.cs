using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;

namespace Restaurante.Client.Managers;

public interface IUsuarioManager
{
    Task<ResultList<UsuarioRecord>> GetAsync();
}

public class UsuarioManager : IUsuarioManager
{
    private readonly HttpClient httpClient;

    public UsuarioManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<UsuarioRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(UsuarioRouteManager.BASE);
            var resultado = await response.ToResultList<UsuarioRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<UsuarioRecord>.Fail(e.Message);
        }
    }
}