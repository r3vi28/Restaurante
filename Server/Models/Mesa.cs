using System.ComponentModel.DataAnnotations;
using Restaurante.Shared.Records;
using Restaurante.Shared.Requests;

namespace Restaurante.Server.Models;

public class Mesa
{
    [Key]
    public int Id { get; set; }
    public int Tamaño { get; set; }
    public int MesaStatusId { get; set; }
    public virtual MesaStatus MesaStatus { get; set; } = null!;

    public static Mesa Crear(MesaCreateRequest request)
    {
        return new Mesa(){
            Tamaño = request.Tamaño,
            MesaStatusId = request.MesaStatusId
        };
    }

    public void Modificar(MesaUpdateRequest request)
    {
        if(Tamaño != request.Tamaño)
            Tamaño = request.Tamaño;
        if(MesaStatusId != request.MesaStatusId)
            MesaStatusId = request.MesaStatusId;
    }

    public MesaRecord ToRecord()
    {
        return new MesaRecord(Id, Tamaño, MesaStatusId, MesaStatus.ToRecord());
    }
}
