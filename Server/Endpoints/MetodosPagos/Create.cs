using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Server.Context;
using Restaurante.Server.Models;
using Microsoft.EntityFrameworkCore;
using Restaurante.Shared.Routes;

namespace Restaurante.Server.Endpoints.MetodosPagos;

using Request = MetodoPagoCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(MetodoPagoRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var metodo = await dbContext.MetodoPagos.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(metodo != null)
                return Respuesta.Fail($"Ya existe un metodo con el nombre '({request.Nombre})'.");
            #endregion
            metodo = MetodoPago.Crear(request);
            dbContext.MetodoPagos.Add(metodo);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(metodo.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}