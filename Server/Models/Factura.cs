using System.ComponentModel.DataAnnotations;
using Restaurante.Shared.Records;
using Restaurante.Shared.Requests;

namespace Restaurante.Server.Models;

public class Factura
{
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int ProductoId { get; set; }
    public virtual Producto Productos { get; set; } = null!;
    public float CostoTotal { get; set; }
    public int CajeroId { get; set; }
    public virtual Usuario CajeroNombre { get; set; } = null!;
    public int MetodoPagoId { get; set; }
    public virtual MetodoPago MetodoPago { get; set; } = null!;

    public static Factura Crear(FacturaCreateRequest request)
    {
        return new Factura(){
            Date = request.Date,
            ProductoId = request.ProductoId,
            CostoTotal = request.CostoTotal,
            CajeroId = request.CajeroId,
            MetodoPagoId = request.MetodoPagoId
        };
    }

    public void Modificar(FacturaUpdateRequest request)
    {
        if(Date != request.Date)
            Date = request.Date;
        if(ProductoId != request.ProductoId)
            ProductoId = request.ProductoId;
        if(CostoTotal != request.CostoTotal)
            CostoTotal = request.CostoTotal;
        if(CajeroId != request.CajeroId)
            CajeroId = request.CajeroId;
        if(MetodoPagoId != request.MetodoPagoId)
            MetodoPagoId = request.MetodoPagoId;
    }

    public FacturaRecord ToRecord()
    {
        return new FacturaRecord(Id, Date, ProductoId, Productos.ToRecord(), CostoTotal, CajeroId, CajeroNombre.ToRecord(), MetodoPagoId, MetodoPago.ToRecord());
    }
}
