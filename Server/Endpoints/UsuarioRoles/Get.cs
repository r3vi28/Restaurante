using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Context;
using Restaurante.Shared.Records;
using Restaurante.Shared.Routes;
using Restaurante.Shared.Wrapper;

namespace Restaurante.Server.Endpoints.UsuarioRoles;
using Respuesta = ResultList<RolUsuarioRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(RolUsuarioRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var roles = await dbContext.RolUsuarios.Select(rol => rol.ToRecord())
        .ToListAsync(cancellationToken);
            return Respuesta.Success(roles);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}
