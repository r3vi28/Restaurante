using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.MetodosPagos;
using Respuesta = Result<MetodoPagoRecord>;
using Request = MetodoPagoRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(MetodoPagoRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var metodo = await dbContext.MetodoPagos
            .Where(m => m.Id == request.Id)
            .Select(metodo => metodo.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(metodo == null)
            return Respuesta.Fail($"No fue posible encontrar el metodo de pago '{request.Id}'");

            return Respuesta.Sucess(metodo);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}
