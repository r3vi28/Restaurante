using System.ComponentModel.DataAnnotations;
using Restaurante.Shared.Records;
using Restaurante.Shared.Requests;

namespace Restaurante.Server.Models;

public class Cliente
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;

    public static Cliente Crear(ClienteCreateRequest request)
    {
        return new Cliente(){
            Nombre = request.Nombre,
            Direccion = request.Direccion,
            Telefono = request.Telefono
        };
    }

    public void Modificar(ClienteUpdateRequest request)
    {
        if(Nombre != request.Nombre)
            Nombre = request.Nombre;
        if(Direccion != request.Direccion)
            Direccion = request.Direccion;
        if(Telefono != request.Telefono)
            Telefono = request.Telefono;
    }

    public ClienteRecord ToRecord()
    {
        return new ClienteRecord(Id, Nombre, Direccion, Telefono);
    }
}
