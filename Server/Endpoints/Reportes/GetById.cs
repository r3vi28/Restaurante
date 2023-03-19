using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.Reportes;
using Respuesta = Result<ReporteRecord>;
using Request = ReporteRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(ReporteRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var reporte = await dbContext.Reportes
            .Where(r => r.Id == request.Id)
            .Select(reporte => reporte.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(reporte == null)
            return Respuesta.Fail($"No fue posible encontrar el rol '{request.Id}'");

            return Respuesta.Sucess(reporte);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}
