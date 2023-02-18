
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class AsignacionMesaCreateRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id valido")]
    public int MesaId { get; set; }
    [Required(ErrorMessage = "Ingrese una hora valida")]
    public DateTime Hora { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id valido")]
    public int MesaStatusId { get; set; }
}