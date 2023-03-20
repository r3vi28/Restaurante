
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class PedidoStatusUpdateRequest: PedidoStatusCreateRequest
{
    [Required(ErrorMessage = "Ingrese un Id valido")]
    public int Id { get; set; }
}
