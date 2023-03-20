
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class MesaUpdateRequest: MesaCreateRequest
{
    [Required(ErrorMessage = "Ingrese un Id valido")]
    public int Id { get; set; }
}
