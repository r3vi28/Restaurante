
namespace Restaurante.Shared.Records;

public class ReporteRecord
{
    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinal { get; set; }
    public int ProductosMasVendidosId { get; set; }
    public virtual List<ProductoRecord> ProductosMasVendidos { get; set; } = null!;
    public float VentasTotales { get; set; }
}

