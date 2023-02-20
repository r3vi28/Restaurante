using System.ComponentModel.DataAnnotations;
using Restaurante.Shared.Records;
using Restaurante.Shared.Requests;

namespace Restaurante.Server.Models;

// public enum RolUsuario
// {
//     Cajero,
//     Gerente,
//     Administrador
// }
public class RolUsuario
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public bool PermisoParaCrear { get; set; }
    public bool PermisoParaEditar { get; set; }
    public bool PermisoParaEliminar { get; set; }

    public static RolUsuario Crear(RolUsuarioCreateRequest request)
    {
        return new RolUsuario(){
            Nombre = request.Nombre,
            PermisoParaCrear = request.PermisoParaCrear,
            PermisoParaEditar = request.PermisoParaEditar,
            PermisoParaEliminar = request.PermisoParaEliminar
        };
    }

    public void Modificar(RolUsuarioUpdateRequest request)
    {
        if(Nombre != request.Nombre)
            Nombre = request.Nombre;
        if(PermisoParaCrear != request.PermisoParaCrear)
            PermisoParaCrear = request.PermisoParaCrear;
        if(PermisoParaEditar != request.PermisoParaEditar)
            PermisoParaEditar = request.PermisoParaEditar;
        if(PermisoParaEliminar != request.PermisoParaEliminar)
            PermisoParaEliminar = request.PermisoParaEliminar;
    }

    public RolUsuarioRecord ToRecord()
    {
        return new RolUsuarioRecord(Id, Nombre, PermisoParaCrear, PermisoParaEditar, PermisoParaEliminar);
    }
}
