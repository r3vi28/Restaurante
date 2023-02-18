
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class PedidoCreateRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id valido")]
    public int ProductoId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id valido")]
    public int PedidoStatusId { get; set; }
    [Required(ErrorMessage = "Ingrese una hora valida")]
    public DateTime DeliveryTime { get; set; }
}

