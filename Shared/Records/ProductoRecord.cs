
namespace Restaurante.Shared.Records;

public class ProductoRecord
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public float Precio { get; set; }
}

