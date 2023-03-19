using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Server.Context;
using Restaurante.Server.Models;
using Microsoft.EntityFrameworkCore;
using Restaurante.Shared.Routes;

namespace Restaurante.Server.Endpoints.Productos;

using Request = ProductoCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(ProductoRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var producto = await dbContext.Productos.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(producto != null)
                return Respuesta.Fail($"Ya existe un producto con el nombre '({request.Nombre})'.");
            #endregion
           producto = Producto.Crear(request);
            dbContext.Productos.Add(producto);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(producto.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}