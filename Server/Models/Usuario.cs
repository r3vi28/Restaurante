using System.ComponentModel.DataAnnotations;

namespace Restaurante.Server.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    public int UsuarioRolId { get; set; }
    public virtual RolUsuario UsuarioRol { get; set;} = null!;
    public string Nombre { get; set; } = null!;
    public string NombreUsuario { get; set; } = null!;
    public string Password { get; set; } = null!;
}