
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Shared.Requests;

public class RolUsuarioUpdateRequest: RolUsuarioCreateRequest
{
    [Required(ErrorMessage = "Se debe proporcionar el Id del rol a modificar")]
    public int Id { get; set; }
}