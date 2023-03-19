using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Server.Context;
using Restaurante.Server.Models;
using Microsoft.EntityFrameworkCore;
using Restaurante.Shared.Routes;

namespace Restaurante.Server.Endpoints.Reportes;

using Request = ReporteCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(ReporteRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var reporte = await dbContext.Reportes.FirstOrDefaultAsync(r => r.FechaInicio == request.FechaInicio && r.FechaFinal == r.FechaFinal,cancellationToken);
            if(reporte != null)
                return Respuesta.Fail($"Ya existe un reporte con las siguientes fechas '({request.FechaInicio})' y '({request.FechaFinal})'.");
            #endregion
            reporte = Reporte.Crear(request);
            dbContext.Reportes.Add(reporte);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(reporte.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}