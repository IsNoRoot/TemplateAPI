using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TemplateAPI.Application.Services;

public class TokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(int userId, string userName)
    {
        // 1. Obtener la clave secreta desde appsettings.json
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        // 2. Crear las credenciales de firma con la clave y el algoritmo
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // 3. Definir los "Claims" (la información que llevará el token)
        var claims = new[]
        {
            // Claims estándar (sub = subject/ID, jti = JWT ID)
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            
            // Claims personalizados
            new Claim(ClaimTypes.Name, userName),
        };

        // 4. Crear el objeto del token con sus propiedades
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1), // El token expira en 1 hora
            signingCredentials: credentials);

        // 5. Generar y devolver el string del token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}