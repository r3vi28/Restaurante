
namespace Restaurante.Shared.Records;

public class PedidoRecord
{
    public PedidoRecord()
    {
        
    }
    public PedidoRecord(int id, int productoId, List<ProductoRecord> productos, int pedidoStatusId, PedidoStatusRecord status, DateTime deliveryTime)
    {
        Id = id;
        ProductoId = productoId;
        Productos = productos;
        PedidoStatusId = pedidoStatusId;
        Status = status;
        DeliveryTime = deliveryTime;
    }

    public int Id { get; set; }
    public int ProductoId { get; set; }
    public virtual List<ProductoRecord> Productos { get; set; } = null!;
    public int PedidoStatusId { get; set; }
    public virtual PedidoStatusRecord Status { get; set; } = null!;
    public DateTime DeliveryTime { get; set; }
}

