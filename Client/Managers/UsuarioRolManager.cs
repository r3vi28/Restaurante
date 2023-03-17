using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;

namespace Restaurante.Client.Managers;

public interface IUsuarioRolManager
{
    Task<ResultList<RolUsuarioRecord>> GetAsync();
}

public class UsuarioRolManager : IUsuarioRolManager
{
    private readonly HttpClient httpClient;

    public UsuarioRolManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<RolUsuarioRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(RolUsuarioRouteManager.BASE);
            var resultado = await response.ToResultList<RolUsuarioRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<RolUsuarioRecord>.Fail(e.Message);
        }
    }
}