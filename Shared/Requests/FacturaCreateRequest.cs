
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class FacturaCreateRequest
{

    [Required(ErrorMessage = "Ingrese una hora valida")]
    public DateTime Date { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id valido")]
    public int ProductoId { get; set; }
    public float CostoTotal { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id valido")]
    public int CajeroId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id valido")]
    public int MetodoPagoId { get; set; }
}
