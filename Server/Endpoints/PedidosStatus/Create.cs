using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Server.Context;
using Restaurante.Server.Models;
using Microsoft.EntityFrameworkCore;
using Restaurante.Shared.Routes;

namespace Restaurante.Server.Endpoints.PedidosStatus;

using Request = PedidoStatusCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(PedidoStatusRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var pedido = await dbContext.PedidoStatuses.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(pedido != null)
                return Respuesta.Fail($"Ya existe un estado de pedido con el nombre '({request.Nombre})'.");
            #endregion
            pedido = PedidoStatus.Crear(request);
            dbContext.PedidoStatuses.Add(pedido);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(pedido.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}