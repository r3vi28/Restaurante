using System.ComponentModel.DataAnnotations;

namespace Restaurante.Server.Models;

public class Reservacion
{
    [Key]
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public int NumeroPersonas { get; set; }
    public int MesaId { get; set; }
    public virtual Mesa MesaElegida { get; set; } = null!;
}
