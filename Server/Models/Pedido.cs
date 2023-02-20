using System.ComponentModel.DataAnnotations;
using Restaurante.Shared.Records;
using Restaurante.Shared.Requests;

namespace Restaurante.Server.Models;

public class Pedido
{
    [Key]
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public virtual Producto Productos { get; set; } = null!;
    public int PedidoStatusId { get; set; }
    public virtual PedidoStatus PedidoStatus { get; set; } = null!;
    public DateTime DeliveryTime { get; set; }

    public static Pedido Crear(PedidoCreateRequest request)
    {
        return new Pedido(){
            ProductoId = request.ProductoId,
            PedidoStatusId = request.PedidoStatusId,
            DeliveryTime = request.DeliveryTime
        };
    }

    public void Modificar(PedidoUpdateRequest request)
    {
        if(ProductoId != request.ProductoId)
            ProductoId = request.ProductoId;
        if(PedidoStatusId != request.PedidoStatusId)
            PedidoStatusId = request.PedidoStatusId;
        if(DeliveryTime != request.DeliveryTime)
            DeliveryTime = request.DeliveryTime;
    }

    public PedidoRecord ToRecord()
    {
        return new PedidoRecord(Id, ProductoId, Productos.ToRecord(), PedidoStatusId, PedidoStatus.ToRecord(), DeliveryTime);
    }
}
