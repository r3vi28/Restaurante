using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.UsuarioRoles;
using Respuesta = Result<RolUsuarioRecord>;
using Request = RolUsuarioRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(RolUsuarioRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var rol = await dbContext.RolUsuarios
            .Where(r => r.Id == request.Id)
            .Select(rol => rol.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(rol == null)
            return Respuesta.Fail($"No fue posible encontrar el rol '{request.Id}'");

            return Respuesta.Sucess(rol);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}
