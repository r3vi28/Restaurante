
namespace Restaurante.Shared.Requests;

public class PedidoCreateRequest
{
    public int ProductoId { get; set; }
    public int PedidoStatusId { get; set; }
    public DateTime DeliveryTime { get; set; }
}

