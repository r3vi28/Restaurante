
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class ProductoUpdateRequest: ProductoCreateRequest
{
    [Required(ErrorMessage = "Ingrese un Id valido")]
    public int Id { get; set; }
}
