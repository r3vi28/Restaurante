
namespace Restaurante.Shared.Requests;

public class ProductoCreateRequest
{
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public float Precio { get; set; }
}
