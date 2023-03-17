using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Client.Extensions;

namespace Restaurante.Client.Managers;

public interface IReservacionManager
{
    Task<ResultList<ReservacionRecord>> GetAsync();
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
}
