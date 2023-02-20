
namespace Restaurante.Shared.Records;

public class ClienteRecord
{
    public ClienteRecord()
    {
        
    }
    public ClienteRecord(int id, string nombre, string direccion, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
}

