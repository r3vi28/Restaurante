using System.ComponentModel.DataAnnotations;
using Restaurante.Shared.Requests;

namespace Restaurante.Server.Models;

public class Mesa
{
    [Key]
    public int Id { get; set; }
    public int Tamaño { get; set; }

    public static Mesa Crear(MesaCreateRequest request)
    {
        return new Mesa(){
            Tamaño = request.Tamaño
        };
    }

    public void Modificar(MesaUpdateRequest request)
    {
        if(Tamaño != request.Tamaño)
            Tamaño = request.Tamaño;
    }
}
