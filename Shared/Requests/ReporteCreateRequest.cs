
namespace Restaurante.Shared.Requests;

public class ReporteCreateRequest
{
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinal { get; set; }
    public int ProductosMasVendidosId { get; set; }
    public float VentasTotales { get; set; }
}
