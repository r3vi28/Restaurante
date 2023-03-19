using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.Pedidos;
using Respuesta = Result<PedidoRecord>;
using Request = PedidoRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(PedidoRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var pedido = await dbContext.Pedidos
            .Where(p => p.Id == request.Id)
            .Select(pedido => pedido.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(pedido == null)
            return Respuesta.Fail($"No fue posible encontrar el pedido '{request.Id}'");

            return Respuesta.Sucess(pedido);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}
