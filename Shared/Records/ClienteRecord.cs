
namespace Restaurante.Shared.Records;

public class ClienteRecord
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
}

