
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class FacturaUpdateRequest: FacturaCreateRequest
{
    [Required(ErrorMessage = "Ingrese un Id valido")]
    public int Id { get; set; }
}
