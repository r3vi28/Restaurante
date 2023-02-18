
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class MetodoPagoUpdateRequest: MetodoPagoCreateRequest
{
    [   
        Required(ErrorMessage = "Ingrese un Id valido"),
        Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id valido")
    ]
    public int Id { get; set; }
}
