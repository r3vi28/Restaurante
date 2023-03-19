using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Server.Context;
using Restaurante.Server.Models;
using Microsoft.EntityFrameworkCore;
using Restaurante.Shared.Routes;

namespace Restaurante.Server.Endpoints.Pedidos;

using Request = PedidoCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(PedidoRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            var pedido = Pedido.Crear(request);
            dbContext.Pedidos.Add(pedido);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(pedido.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}