
namespace Restaurante.Shared.Records;

public class ProductoRecord
{
    public ProductoRecord()
    {
        
    }
    public ProductoRecord(int id, string nombre, string descripcion, float precio)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public float Precio { get; set; }
}

