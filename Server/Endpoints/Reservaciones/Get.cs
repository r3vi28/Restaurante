using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.Reservaciones;


using Respuesta = ResultList<ReservacionRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(ReservacionRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var reservaciones = await dbContext.Reservaciones.Select(reservacion => reservacion.ToRecord())
        .ToListAsync(cancellationToken);
            return Respuesta.Success(reservaciones);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }
}