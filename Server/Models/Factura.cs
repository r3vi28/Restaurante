using System.ComponentModel.DataAnnotations;

namespace Restaurante.Server.Models;

public class Factura
{
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int ProductoId { get; set; }
    public virtual List<Producto> Productos { get; set; } = null!;
    public float CostoTotal { get; set; }
    public int CajeroId { get; set; }
    public virtual Usuario CajeroNombre { get; set; } = null!;
    public int MetodoPagoId { get; set; }
    public virtual MetodoPago MetodoPago { get; set; } = null!;
}
