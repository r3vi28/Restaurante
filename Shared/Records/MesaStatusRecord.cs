
namespace Restaurante.Shared.Records;

public class MesaStatusRecord
{
    public MesaStatusRecord()
    {
        
    }
    public MesaStatusRecord(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
}

