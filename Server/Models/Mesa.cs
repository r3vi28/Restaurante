using System.ComponentModel.DataAnnotations;

namespace Restaurante.Server.Models;

public class Mesa
{
    [Key]
    public int Id { get; set; }
    public int Tamaño { get; set; }
}
