using System.ComponentModel.DataAnnotations;

namespace TemplateAPI.Application.DTOs;

public class UserCreateRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [Range(0,100)]
    public int Age { get; set; }
    [Required]
    [StringLength(50)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string UserName { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string Password { get; set; } = string.Empty;
}