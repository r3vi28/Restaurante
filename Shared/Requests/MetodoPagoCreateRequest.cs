
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class MetodoPagoCreateRequest
{
    [
        Required(ErrorMessage = "Ingrese un nombre valido"),
        MinLength(5, ErrorMessage = "El nombre debe poseer al menos 5 caracteres"),
        MaxLength(100, ErrorMessage = "El nombre debe poseer como maximo 100 caracteres")
    ]
    public string Nombre { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese una descripción valida"),
        MinLength(5, ErrorMessage = "La descripción debe poseer al menos 5 caracteres"),
        MaxLength(100, ErrorMessage = "La descripción debe poseer como maximo 100 caracteres")
    ]
    public string Descripcion { get; set; } = null!;
}
