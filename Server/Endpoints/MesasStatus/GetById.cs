using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.MesasStatus;
using Respuesta = Result<MesaRecord>;
using Request = MesaRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(MesaRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var mesa = await dbContext.Mesas
            .Where(m => m.Id == request.Id)
            .Select(mesa => mesa.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(mesa == null)
            return Respuesta.Fail($"No fue posible encontrar el estado de mesa '{request.Id}'");

            return Respuesta.Sucess(mesa);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}
