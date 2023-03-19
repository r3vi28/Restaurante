using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;
using Restaurante.Shared.Requests;
using System.Net.Http.Json;

namespace Restaurante.Client.Managers;

public interface IReservacionManager
{
    Task<ResultList<ReservacionRecord>> GetAsync();
    Task<Result<int>> CreateAsync(ReservacionCreateRequest request);
    Task<Result<ReservacionRecord>> GetByIdAsync(int Id);
}

public class ReservacionManager : IReservacionManager
{
    private readonly HttpClient httpClient;

    public ReservacionManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<ReservacionRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(ReservacionRouteManager.BASE);
            var resultado = await response.ToResultList<ReservacionRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<ReservacionRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(ReservacionCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(ReservacionRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<ReservacionRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(ReservacionRouteManager.BuildRoute(Id));
        return await response.ToResult<ReservacionRecord>();
    }
}
