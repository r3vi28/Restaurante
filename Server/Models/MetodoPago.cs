using Restaurante.Shared.Records;
using Restaurante.Shared.Requests;

namespace Restaurante.Server.Models;

public class MetodoPago
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    // Metodos de pago = Efectivo, Tarjeta, InternetBanking

    public static MetodoPago Crear(MetodoPagoCreateRequest request)
    {
        return new MetodoPago(){
            Nombre = request.Nombre,
            Descripcion = request.Descripcion
        };
    }

    public void Modificar(MetodoPagoUpdateRequest request)
    {
        if(Nombre != request.Nombre)
            Nombre = request.Nombre;
        if(Descripcion != request.Descripcion)
            Descripcion = request.Descripcion;
    }

    public MetodoPagoRecord ToRecord()
    {
        return new MetodoPagoRecord(Id, Nombre, Descripcion);
    }
}
