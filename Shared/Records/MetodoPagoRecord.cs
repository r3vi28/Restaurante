
namespace Restaurante.Shared.Records;

public class MetodoPagoRecord
{
    public MetodoPagoRecord()
    {
        
    }
    public MetodoPagoRecord(int id, string nombre, string descripcion)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
}

