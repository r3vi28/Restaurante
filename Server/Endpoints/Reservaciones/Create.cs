using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Server.Context;
using Restaurante.Server.Models;
using Microsoft.EntityFrameworkCore;
using Restaurante.Shared.Routes;

namespace Restaurante.Server.Endpoints.Reservaciones;

using Request = ReservacionCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(ReservacionRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var reservacion = await dbContext.Reservaciones.FirstOrDefaultAsync(r => r.MesaId == request.MesaId && r.Fecha == request.Fecha,cancellationToken);
            if(reservacion != null)
                return Respuesta.Fail($"Ya existe una reservacion con hora y fecha '({request.Fecha})', y mesa ''({request.MesaId}).");
            #endregion
            reservacion = Reservacion.Crear(request);
            dbContext.Reservaciones.Add(reservacion);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(reservacion.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}