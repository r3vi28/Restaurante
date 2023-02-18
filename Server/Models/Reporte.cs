using System.ComponentModel.DataAnnotations;

namespace Restaurante.Server.Models;

public class Reporte
{
    [Key]
    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinal { get; set; }
    public int ProductosMasVendidosId { get; set; }
    public virtual List<Producto> ProductosMasVendidos { get; set; } = null!;
    public float VentasTotales { get; set; }
}
