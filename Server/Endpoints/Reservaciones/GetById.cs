using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.Reservaciones;
using Respuesta = Result<ReservacionRecord>;
using Request = ReservacionRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(ReservacionRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var reservacion = await dbContext.Reservaciones
            .Where(r => r.Id == request.Id)
            .Select(reservacion => reservacion.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(reservacion == null)
            return Respuesta.Fail($"No fue posible encontrar el rol '{request.Id}'");

            return Respuesta.Sucess(reservacion);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}
