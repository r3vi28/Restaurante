
namespace Restaurante.Shared.Records;

public class MesaRecord
{
    public MesaRecord()
    {
        
    }
    public MesaRecord(int id, int tamaño, int mesaStatusId, MesaStatusRecord mesaStatus)
    {
        Id = id;
        Tamaño = tamaño;
        MesaStatusId  = mesaStatusId;
        MesaStatus = mesaStatus;
    }

    public int Id { get; set; }
    public int Tamaño { get; set; }
    public int MesaStatusId { get; set; }
    public virtual MesaStatusRecord MesaStatus { get; set; } = null!;
}

