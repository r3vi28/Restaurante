using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.MesasStatus;


using Respuesta = ResultList<MesaStatusRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(MesaStatusRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var mesasStatuses = await dbContext.MesaStatuses.Select(mesastatus => mesastatus.ToRecord())
        .ToListAsync(cancellationToken);
            return Respuesta.Success(mesasStatuses);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }
}