
namespace Restaurante.Shared.Requests;

public class UsuarioCreateRequest
{
    public int UsuarioRolId { get; set; }
    public string Nombre { get; set; } = null!;
    public string NombreUsuario { get; set; } = null!;
    public string Password { get; set; } = null!;
}
