using System.ComponentModel.DataAnnotations;

namespace Restaurante.Server.Models;

public class PedidoStatus
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    // PedidosStatus = Pendiente, Confirmado, Entregado
}