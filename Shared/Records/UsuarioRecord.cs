
namespace Restaurante.Shared.Records;

public class UsuarioRecord
{
    public int Id { get; set; }
    public int UsuarioRolId { get; set; }
    public virtual RolUsuarioRecord UsuarioRol { get; set;} = null!;
    public string Nombre { get; set; } = null!;
    public string NombreUsuario { get; set; } = null!;
    public string Password { get; set; } = null!;
}

