
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class ReservacionCreateRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id valido")]
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "Ingrese una fecha valida")]
    public DateTime Fecha { get; set; }
    [Required(ErrorMessage = "Ingrese una hora valida")]
    public TimeSpan Hora { get; set; }
    [Required(ErrorMessage = "Ingrese un valor valido")]
    public int NumeroPersonas { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id valido")]
    public int MesaId { get; set; }
}
