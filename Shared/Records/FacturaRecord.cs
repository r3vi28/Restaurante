
namespace Restaurante.Shared.Records;

public class FacturaRecord
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int ProductoId { get; set; }
    public virtual List<ProductoRecord> Productos { get; set; } = null!;
    public float CostoTotal { get; set; }
    public int CajeroId { get; set; }
    public virtual UsuarioRecord CajeroNombre { get; set; } = null!;
    public int MetodoPagoId { get; set; }
    public virtual MetodoPagoRecord MetodoPago { get; set; } = null!;
}

