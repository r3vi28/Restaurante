
namespace Restaurante.Shared.Requests;

public class AsignacionMesaCreateRequest
{
    public int MesaId { get; set; }
    public DateTime Hora { get; set; }
    public int MesaStatusId { get; set; }
}
