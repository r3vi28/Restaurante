using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.Pedidos;


using Respuesta = ResultList<PedidoRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(PedidoStatusRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var pedidos = await dbContext.Pedidos.Select(pedido => pedido.ToRecord())
        .ToListAsync(cancellationToken);
            return Respuesta.Success(pedidos);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }
}