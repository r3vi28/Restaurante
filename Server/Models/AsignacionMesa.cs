using System.ComponentModel.DataAnnotations;
using Restaurante.Shared.Records;
using Restaurante.Shared.Requests;

namespace Restaurante.Server.Models;

public class AsignacionMesa
{
    [Key]
    public int Id { get; set; }
    public int MesaId { get; set; }
    public virtual Mesa Mesa { get; set; } = null!;
    public DateTime Hora { get; set; }
    public int MesaStatusId { get; set; }
    public virtual MesaStatus MesaStatus { get; set; } = null!;

    public static AsignacionMesa Crear(AsignacionMesaCreateRequest request)
        {
            return new AsignacionMesa(){
                MesaId = request.MesaId,
                Hora = request.Hora,
                MesaStatusId = request.MesaStatusId,
            };
        }

    public void Modificar(AsignacionMesaUpdateRequest request){
            if(MesaId != request.MesaId)
                MesaId = request.MesaId;
            if(Hora != request.Hora)
                Hora = request.Hora;
            if(MesaStatusId != request.MesaStatusId)
                Hora = request.Hora;
        }
    
    public AsignacionMesaRecord ToRecord()
    {
        return new AsignacionMesaRecord(Id, MesaId, Mesa.ToRecord(), Hora, MesaStatusId, MesaStatus.ToRecord());
    }
}
