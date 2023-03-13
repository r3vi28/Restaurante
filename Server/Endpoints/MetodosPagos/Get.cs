using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.MetodosPagos;


using Respuesta = ResultList<MetodoPagoRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(MetodoPagoRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var metodospagos = await dbContext.MetodoPagos.Select(metodopago => metodopago.ToRecord())
        .ToListAsync(cancellationToken);
            return Respuesta.Success(metodospagos);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }
}