using System.ComponentModel.DataAnnotations;

namespace Restaurante.Server.Models;

public class Pedido
{
    [Key]
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public virtual List<Producto> Productos { get; set; } = null!;
    public int PedidoStatusId { get; set; }
    public virtual PedidoStatus Status { get; set; } = null!;
    public DateTime DeliveryTime { get; set; }
}
