using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.PedidosStatus;


using Respuesta = ResultList<PedidoStatusRecord>;

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
            var pedidosStatuses = await dbContext.PedidoStatuses.Select(pedidoStatus => pedidoStatus.ToRecord())
        .ToListAsync(cancellationToken);
            return Respuesta.Success(pedidosStatuses);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }
}