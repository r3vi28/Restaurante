
namespace Restaurante.Shared.Records;

public class ReporteRecord
{
    public ReporteRecord()
    {
        
    }

    public ReporteRecord(int id, DateTime fechaInicio, DateTime fechaFinal, int productosMasVendidosId, ProductoRecord productosMasVendidos, float ventasTotales)
    {
        Id = id;
        FechaInicio = fechaInicio;
        FechaFinal = fechaFinal;
        ProductosMasVendidosId = productosMasVendidosId;
        ProductosMasVendidos = productosMasVendidos;
        VentasTotales = ventasTotales;
    }

    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinal { get; set; }
    public int ProductosMasVendidosId { get; set; }
    public virtual ProductoRecord ProductosMasVendidos { get; set; } = null!;
    public float VentasTotales { get; set; }
}

