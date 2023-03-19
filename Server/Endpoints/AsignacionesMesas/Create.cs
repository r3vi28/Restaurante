using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Server.Context;
using Restaurante.Server.Models;
using Microsoft.EntityFrameworkCore;
using Restaurante.Shared.Routes;

namespace Restaurante.Server.Endpoints.AsignacionesMesas;

using Request = AsignacionMesaCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(AsignacionMesaRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var asignacion = await dbContext.AsignacionMesas.FirstOrDefaultAsync(r => r.MesaId == request.MesaId,cancellationToken);
            if(asignacion != null)
                return Respuesta.Fail($"Esta asignada la mesa'({request.MesaId})'.");
            #endregion
            asignacion = AsignacionMesa.Crear(request);
            dbContext.AsignacionMesas.Add(asignacion);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(asignacion.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}