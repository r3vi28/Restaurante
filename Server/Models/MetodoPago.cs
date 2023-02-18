namespace Restaurante.Server.Models;

public class MetodoPago
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    // Metodos de pago = Efectivo, Tarjeta, InternetBanking
}
