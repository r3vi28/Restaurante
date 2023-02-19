
namespace Restaurante.Shared.Records;

public class AsignacionMesaRecord
{
    public int Id { get; set; }
    public int MesaId { get; set; }
    public virtual MesaRecord Mesa { get; set; } = null!;
    public DateTime Hora { get; set; }
    public int MesaStatusId { get; set; }
    public virtual List<MesaStatusRecord> MesaStatus { get; set; } = null!;
}