using System.ComponentModel.DataAnnotations;
using Restaurante.Shared.Records;
using Restaurante.Shared.Requests;

namespace Restaurante.Server.Models;

public class Reporte
{
    [Key]
    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinal { get; set; }
    public int ProductosMasVendidosId { get; set; }
    public virtual Producto ProductosMasVendidos { get; set; } = null!;
    public float VentasTotales { get; set; }

    public static Reporte Crear(ReporteCreateRequest request)
    {
        return new Reporte(){
            FechaInicio = request.FechaInicio,
            FechaFinal = request.FechaFinal,
            ProductosMasVendidosId = request.ProductosMasVendidosId,
            VentasTotales = request.VentasTotales
        };
    }

    public void Modificar(ReporteUpdateRequest request)
    {
        if(FechaInicio != request.FechaInicio)
            FechaInicio = request.FechaInicio;
        if(FechaFinal != request.FechaFinal)
            FechaFinal = request.FechaFinal;
        if(ProductosMasVendidosId != request.ProductosMasVendidosId)
            ProductosMasVendidosId = request.ProductosMasVendidosId;
        if(VentasTotales != request.VentasTotales)
            VentasTotales = request.VentasTotales;
    }

    public ReporteRecord ToRecord()
    {
        return new ReporteRecord(Id, FechaInicio, FechaFinal, ProductosMasVendidosId, ProductosMasVendidos.ToRecord(), VentasTotales);
    }
}
