
namespace Restaurante.Shared.Requests;

public class ClienteCreateRequest
{
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
}
