
namespace Restaurante.Shared.Records;

public class ReservacionRecord
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public virtual ClienteRecord Cliente { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public int NumeroPersonas { get; set; }
    public int MesaId { get; set; }
    public virtual MesaRecord MesaElegida { get; set; } = null!;
}

