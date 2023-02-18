
namespace Restaurante.Shared.Requests;

public class FacturaCreateRequest
{
    public DateTime Date { get; set; }
    public int ProductoId { get; set; }
    public float CostoTotal { get; set; }
    public int CajeroId { get; set; }
    public int MetodoPagoId { get; set; }
}
