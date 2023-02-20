
namespace Restaurante.Shared.Records;

public class PedidoStatusRecord
{
    public PedidoStatusRecord()
    {
        
    }
    public PedidoStatusRecord(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
}

