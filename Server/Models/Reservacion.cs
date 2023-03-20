using System.ComponentModel.DataAnnotations;
using Restaurante.Shared.Records;
using Restaurante.Shared.Requests;

namespace Restaurante.Server.Models;

public class Reservacion
{
    [Key]
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public int NumeroPersonas { get; set; }
    public int MesaId { get; set; }
    public virtual Mesa MesaElegida { get; set; } = null!;

    public static Reservacion Crear(ReservacionCreateRequest request)
    {
        return new Reservacion(){
            ClienteId = request.ClienteId,
            Fecha = request.Fecha,
            NumeroPersonas = request.NumeroPersonas,
            MesaId = request.MesaId
        };
    }

    public void Modificar(ReservacionUpdateRequest request)
    {
        if(ClienteId != request.ClienteId)
            ClienteId = request.ClienteId;
        if(Fecha != request.Fecha)
            Fecha = request.Fecha;
        if(NumeroPersonas != request.NumeroPersonas)
            NumeroPersonas = request.NumeroPersonas;
        if(MesaId != request.MesaId)
            MesaId = request.MesaId;
    }

    public ReservacionRecord ToRecord()
    {
        return new ReservacionRecord(Id, ClienteId, Cliente.ToRecord(), Fecha, NumeroPersonas, MesaId, MesaElegida.ToRecord());
    }
}
