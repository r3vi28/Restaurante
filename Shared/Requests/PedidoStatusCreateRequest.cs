
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class PedidoStatusCreateRequest
{
    [   
        Required(ErrorMessage = "Ingrese un Id valido"),
        Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id valido")
    ]
    public string Nombre { get; set; } = null!;
}
