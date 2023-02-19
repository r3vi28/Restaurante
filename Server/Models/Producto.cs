using System.ComponentModel.DataAnnotations;
using Restaurante.Shared.Requests;

namespace Restaurante.Server.Models;

public class Producto
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public float Precio { get; set; }

    public static Producto Crear(ProductoCreateRequest request)
    {
        return new Producto(){
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Precio = request.Precio
        };
    }

    public void Modificar(ProductoUpdateRequest request)
    {
        if(Nombre != request.Nombre)
            Nombre = request.Nombre;
        if(Descripcion != request.Descripcion)
            Descripcion = request.Descripcion;
        if(Precio != request.Precio)
            Precio = request.Precio;
    }
}
