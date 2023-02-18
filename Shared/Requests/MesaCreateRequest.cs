
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class MesaCreateRequest
{
    [Required(ErrorMessage = "Ingrese un valor valido")]
    public int Tamaño { get; set; }
}
