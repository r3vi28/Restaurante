using System.ComponentModel.DataAnnotations;

namespace Restaurante.Server.Models;

public class Cliente
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
}
