using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.AsignacionesMesas;
using Respuesta = Result<AsignacionMesaRecord>;
using Request = AsignacionMesaRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(AsignacionMesaRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var asignacion = await dbContext.AsignacionMesas
            .Where(a => a.Id == request.Id)
            .Select(asignacion => asignacion.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(asignacion == null)
            return Respuesta.Fail($"No fue posible encontrar la asignación '{request.Id}'");

            return Respuesta.Sucess(asignacion);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}
