using System.ComponentModel.DataAnnotations;
using Restaurante.Shared.Requests;

namespace Restaurante.Server.Models;

public class MesaStatus
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    // MesaStatus = Disponible, Reservada, Ocupada

    public static MesaStatus Crear(MesaStatusCreateRequest request)
    {
        return new MesaStatus(){
            Nombre = request.Nombre
        };
    }

    public void Modificar(MesaStatusUpdateRequest request)
    {
        if(Nombre != request.Nombre)
            Nombre = request.Nombre;
    }
}
