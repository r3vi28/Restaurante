using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Server.Context;
using Restaurante.Server.Models;
using Restaurante.Shared.Routes;

namespace Restaurante.Server.Endpoints.Mesas;

using Request = MesaCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(MesaRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            var mesa = Mesa.Crear(request);
            dbContext.Mesas.Add(mesa);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(mesa.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}