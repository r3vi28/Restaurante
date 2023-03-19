using Restaurante.Shared.Wrapper;
using Restaurante.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Server.Context;
using Restaurante.Server.Models;
using Microsoft.EntityFrameworkCore;
using Restaurante.Shared.Routes;

namespace Restaurante.Server.Endpoints.MesasStatus;

using Request = MesaStatusCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(MesaStatusRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var mesa = await dbContext.MesaStatuses.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(mesa != null)
                return Respuesta.Fail($"Ya existe estado de mesa con el nombre '({request.Nombre})'.");
            #endregion
            mesa = MesaStatus.Crear(request);
            dbContext.MesaStatuses.Add(mesa);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(mesa.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}