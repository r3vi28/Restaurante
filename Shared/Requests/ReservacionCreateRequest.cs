
namespace Restaurante.Shared.Requests;

public class ReservacionCreateRequest
{
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public int NumeroPersonas { get; set; }
    public int MesaId { get; set; }
}
