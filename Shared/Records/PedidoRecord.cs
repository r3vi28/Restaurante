
namespace Restaurante.Shared.Records;

public class PedidoRecord
{
    public PedidoRecord()
    {
        
    }

    public PedidoRecord(int id, int productoId, ProductoRecord productos, int pedidoStatusId, PedidoStatusRecord pedidoStatus, DateTime deliveryTime)
    {
        Id = id;
        ProductoId = productoId;
        Productos = productos;
        PedidoStatusId = pedidoStatusId;
        PedidoStatus = pedidoStatus;
        DeliveryTime = deliveryTime;
    }

    public int Id { get; set; }
    public int ProductoId { get; set; }
    public virtual ProductoRecord Productos { get; set; } = null!;
    public int PedidoStatusId { get; set; }
    public virtual PedidoStatusRecord PedidoStatus { get; set; } = null!;
    public DateTime DeliveryTime { get; set; }
}

