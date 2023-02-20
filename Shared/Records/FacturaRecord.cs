
namespace Restaurante.Shared.Records;

public class FacturaRecord
{
    public FacturaRecord()
    {
        
    }

    public FacturaRecord(int id, DateTime date, int productoId, ProductoRecord productos, float costoTotal, int cajeroId, UsuarioRecord cajeroNombre, int metodoPagoId, MetodoPagoRecord metodoPago)
    {
        Id = id;
        Date = date;
        ProductoId = productoId;
        Productos = productos;
        CostoTotal = costoTotal;
        CajeroId = cajeroId;
        CajeroNombre = cajeroNombre;
        MetodoPagoId = metodoPagoId;
        MetodoPago = metodoPago;
    }

    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int ProductoId { get; set; }
    public virtual ProductoRecord Productos { get; set; } = null!;
    public float CostoTotal { get; set; }
    public int CajeroId { get; set; }
    public virtual UsuarioRecord CajeroNombre { get; set; } = null!;
    public int MetodoPagoId { get; set; }
    public virtual MetodoPagoRecord MetodoPago { get; set; } = null!;
}

