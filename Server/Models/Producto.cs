using System.ComponentModel.DataAnnotations;

namespace Restaurante.Server.Models;

public class Producto
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public float Precio { get; set; }
}
