
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class ClienteCreateRequest
{
    [
        Required(ErrorMessage = "Ingrese un nombre valido"),
        MinLength(5, ErrorMessage = "El nombre debe poseer al menos 5 caracteres"),
        MaxLength(100, ErrorMessage = "El nombre debe poseer como maximo 100 caracteres")
    ]
    public string Nombre { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese una dirección valida"),
        MinLength(5, ErrorMessage = "El nombre debe poseer al menos 5 caracteres"),
        MaxLength(100, ErrorMessage = "El nombre debe poseer como maximo 100 caracteres")
    ]
    public string Direccion { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese un telefono valido"),
        MinLength(10, ErrorMessage = "El telefono debe poseer 10 caracteres"),
        MaxLength(10, ErrorMessage = "El telefono debe poseer 10 caracteres")
    ]
    public string Telefono { get; set; } = null!;
}
