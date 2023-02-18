
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class ReporteCreateRequest
{
    [Required(ErrorMessage = "Ingrese una hora valida")]
    public DateTime FechaInicio { get; set; }
    [Required(ErrorMessage = "Ingrese una hora valida")]
    public DateTime FechaFinal { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id valido")]
    public int ProductosMasVendidosId { get; set; }
    [Required(ErrorMessage = "Ingrese un valor valido")]
    public float VentasTotales { get; set; }
}
