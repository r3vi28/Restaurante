using System.ComponentModel.DataAnnotations;

namespace Restaurante.Server.Models;

public class AsignacionMesa
{
    [Key]
    public int Id { get; set; }
    public int MesaId { get; set; }
    public virtual Mesa Mesa { get; set; } = null!;
    public DateTime Hora { get; set; }
    public int MesaStatusId { get; set; }
    public virtual List<MesaStatus> MesaStatus { get; set; } = null!;
}
