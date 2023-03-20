using System.Net;
using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;
using Restaurante.Shared.Requests;
using System.Net.Http.Json;

namespace Restaurante.Client.Managers;

public interface IUsuarioRolManager
{
    Task<ResultList<RolUsuarioRecord>> GetAsync();
    Task<Result<int>> CreateAsync(RolUsuarioCreateRequest request);
    Task<Result<RolUsuarioRecord>> GetByIdAsync(int Id);
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

    public async Task<Result<int>> CreateAsync(RolUsuarioCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(RolUsuarioRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<RolUsuarioRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(RolUsuarioRouteManager.BuildRoute(Id));
        return await response.ToResult<RolUsuarioRecord>();
    }
}