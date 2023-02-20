
namespace Restaurante.Shared.Records;

public class AsignacionMesaRecord
{
    public AsignacionMesaRecord()
    {
        
    }
    public AsignacionMesaRecord(int id, int mesaId, MesaRecord mesa, DateTime hora, int mesaStatusId, MesaStatusRecord mesaStatus)
    {
        Id = id;
        MesaId = mesaId;
        Mesa = mesa;
        Hora = hora;
        MesaStatusId = mesaStatusId;
        MesaStatus = mesaStatus;
    }

    public int Id { get; set; }
    public int MesaId { get; set; }
    public virtual MesaRecord Mesa { get; set; } = null!;
    public DateTime Hora { get; set; }
    public int MesaStatusId { get; set; }
    public virtual MesaStatusRecord MesaStatus { get; set; } = null!;
}