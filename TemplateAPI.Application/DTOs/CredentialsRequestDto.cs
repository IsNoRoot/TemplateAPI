using System.ComponentModel.DataAnnotations;

namespace TemplateAPI.Application.DTOs;

public class CredentialsRequestDto
{
    [Required(ErrorMessage = "El nombre de usuario es requerido.")]
    [StringLength(50,ErrorMessage = "La longitud maxima para el nombre de usuario es de 50 caracteres.")]
    public string UserName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La contraseña es requerida.")]
    [StringLength(50,ErrorMessage = "La longitud maxima para la constraseña es de 50 caracteres.")]
    public string Password { get; set; }=string.Empty;
}