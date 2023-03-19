using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Server.Context;
using Restaurante.Server.Models;
using Microsoft.EntityFrameworkCore;
using Restaurante.Shared.Routes;

namespace Restaurante.Server.Endpoints.Clientes;

using Request = ClienteCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(ClienteRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{

            #region Validaciones
            var cliente = await dbContext.Clientes.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(cliente != null)
                return Respuesta.Fail($"Ya existe un cliente con el nombre '({request.Nombre})'.");
            #endregion
            cliente = Cliente.Crear(request);
            dbContext.Clientes.Add(cliente);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(cliente.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}