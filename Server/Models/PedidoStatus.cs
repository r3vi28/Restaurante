using System.ComponentModel.DataAnnotations;
using Restaurante.Shared.Records;
using Restaurante.Shared.Requests;

namespace Restaurante.Server.Models;

public class PedidoStatus
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    // PedidosStatus = Pendiente, Confirmado, Entregado

    public static PedidoStatus Crear(PedidoStatusCreateRequest request)
    {
        return new PedidoStatus(){
            Nombre = request.Nombre
        };
    }

    public void Modificar(PedidoStatusUpdateRequest request)
    {
        if(Nombre != request.Nombre)
            Nombre = request.Nombre;
    }

    public PedidoStatusRecord ToRecord()
    {
        return new PedidoStatusRecord(Id, Nombre);
    }
}