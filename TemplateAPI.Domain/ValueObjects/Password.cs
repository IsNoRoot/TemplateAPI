using TemplateAPI.Domain.Exceptions;

namespace TemplateAPI.Domain.ValueObjects;

public class Password
{
    private const int MinLength = 8;
    private const int MaxLength = 20;
    
    public string Value { get; private set; }

    public Password(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new DomainException("La contraseña no puede estar vacía.");
        }

        if (password.Length < MinLength || password.Length > MaxLength)
        {
            throw new DomainException($"La contraseña debe tener entre {MinLength} y {MaxLength} caracteres.");
        }

        Value = password;
    }
    private Password(){}
}