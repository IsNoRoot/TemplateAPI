using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace TemplateAPI.Application.DTOs;

public class UserCreateRequestDto
{
    [Required(ErrorMessage = "El nombre del usuario es requerido.")]
    [StringLength(100,ErrorMessage = "La longitud maxima para el nombre del usuario es de 50 caracteres.")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El apellido paterno del usuario es requerido.")]
    [StringLength(50,ErrorMessage = "La longitud maxima para el apellido paterno del usuario es de 50 caracteres.")]
    public string FirstName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El apellido materno del usuario es requerido.")]
    [StringLength(50,ErrorMessage = "La longitud maxima para el apellido materno del usuario es de 50 caracteres.")]
    public string LastName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La edad del usuario es requerida.")]
    [Range(0,100,ErrorMessage = "La edad del usuario deber estar entre los 0 y 100 años.")]
    public int Age { get; set; }
    
    [Required(ErrorMessage = "El email del usuario es requerido.")]
    [StringLength(50,ErrorMessage = "La longitud maxima para el email del usuario es de 50 caracteres.")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El apodo del usuario es requerido.")]
    [StringLength(50,ErrorMessage = "La longitud maxima para el apodo del usuario es de 50 caracteres.")]
    public string UserName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La contraseña del usuario es requerida.")]
    [StringLength(50,ErrorMessage = "La longitud maxima para la constraseña del usuario es de 50 caracteres.")]
    public string Password { get; set; } = string.Empty;
}