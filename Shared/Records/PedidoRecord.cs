
namespace Restaurante.Shared.Records;

public class PedidoRecord
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public virtual List<ProductoRecord> Productos { get; set; } = null!;
    public int PedidoStatusId { get; set; }
    public virtual PedidoStatusRecord Status { get; set; } = null!;
    public DateTime DeliveryTime { get; set; }
}

