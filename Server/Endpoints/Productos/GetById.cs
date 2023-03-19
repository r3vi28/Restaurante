using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.Productos;
using Respuesta = Result<ProductoRecord>;
using Request = ProductoRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(ProductoRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var producto = await dbContext.Productos
            .Where(p => p.Id == request.Id)
            .Select(producto => producto.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(producto == null)
            return Respuesta.Fail($"No fue posible encontrar el rol '{request.Id}'");

            return Respuesta.Sucess(producto);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}
