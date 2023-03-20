
namespace Restaurante.Shared.Records;

public class ReservacionRecord
{
    public ReservacionRecord()
    {
        
    }
    public ReservacionRecord(int id, int clienteId, ClienteRecord cliente, DateTime fecha, int numeroPersonas, int mesaId, MesaRecord mesaElegida)
    {
        Id = id;
        ClienteId = clienteId;
        Cliente = cliente;
        Fecha = fecha;
        NumeroPersonas = numeroPersonas;
        MesaId = mesaId;
        MesaElegida = mesaElegida;
    }

    public int Id { get; set; }
    public int ClienteId { get; set; }
    public virtual ClienteRecord Cliente { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public int NumeroPersonas { get; set; }
    public int MesaId { get; set; }
    public virtual MesaRecord MesaElegida { get; set; } = null!;
}

