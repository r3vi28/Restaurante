using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.AsignacionesMesas;


using Respuesta = ResultList<AsignacionMesaRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(AsignacionMesaRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var asignaciones = await dbContext.AsignacionMesas.Select(asignacion => asignacion.ToRecord())
        .ToListAsync(cancellationToken);
            return Respuesta.Success(asignaciones);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }
}