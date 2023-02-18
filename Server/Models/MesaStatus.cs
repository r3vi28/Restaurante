using System.ComponentModel.DataAnnotations;

namespace Restaurante.Server.Models;

public class MesaStatus
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    // MesaStatus = Disponible, Reservada, Ocupada
}
