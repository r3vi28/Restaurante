
namespace Restaurante.Shared.Records;

public class MesaRecord
{
    public MesaRecord()
    {
        
    }
    public MesaRecord(int id, int tamaño)
    {
        Id = id;
        Tamaño = tamaño;
    }

    public int Id { get; set; }
    public int Tamaño { get; set; }
}

