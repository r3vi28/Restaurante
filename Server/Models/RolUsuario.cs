using System.ComponentModel.DataAnnotations;

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
}
