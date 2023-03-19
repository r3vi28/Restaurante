using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Server.Context;
using Restaurante.Server.Models;
using Microsoft.EntityFrameworkCore;
using Restaurante.Shared.Routes;

namespace Restaurante.Server.Endpoints.UsuarioRoles;

using Request = RolUsuarioCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(RolUsuarioRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var rol = await dbContext.RolUsuarios.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(rol != null)
                return Respuesta.Fail($"Ya existe un rol con el nombre '({request.Nombre})'.");
            #endregion
            rol = RolUsuario.Crear(request);
            dbContext.RolUsuarios.Add(rol);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(rol.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}