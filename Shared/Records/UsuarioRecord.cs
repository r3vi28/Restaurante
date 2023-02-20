
namespace Restaurante.Shared.Records;

public class UsuarioRecord
{
    public UsuarioRecord()
    {
        
    }
    public UsuarioRecord(int id, int usuarioRolId, RolUsuarioRecord usuarioRol, string nombre, string nombreUsuario, string password)
    {
        Id = id;
        UsuarioRolId = usuarioRolId;
        UsuarioRol = usuarioRol;
        Nombre = nombre;
        NombreUsuario = nombreUsuario;
        Password = password;
    }

    public int Id { get; set; }
    public int UsuarioRolId { get; set; }
    public virtual RolUsuarioRecord UsuarioRol { get; set;} = null!;
    public string Nombre { get; set; } = null!;
    public string NombreUsuario { get; set; } = null!;
    public string Password { get; set; } = null!;
}

