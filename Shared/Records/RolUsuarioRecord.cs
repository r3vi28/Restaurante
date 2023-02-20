
namespace Restaurante.Shared.Records;

public class RolUsuarioRecord
{
    public RolUsuarioRecord()
    {
        
    }
    public RolUsuarioRecord(int id, string nombre, bool permisoParaCrear, bool permisoParaEditar, bool permisoParaEliminar)
    {
        Id = id;
        Nombre = nombre;
        PermisoParaCrear = permisoParaCrear;
        PermisoParaEditar = permisoParaEditar;
        PermisoParaEliminar = permisoParaEliminar;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public bool PermisoParaCrear { get; set; }
    public bool PermisoParaEditar { get; set; }
    public bool PermisoParaEliminar { get; set; }
}

