using TemplateAPI.Domain.Exceptions;

namespace TemplateAPI.Domain.ValueObjects;

public class Email
{
    private List<string> _allowedDomains = ["map.com.mx", "outlook.com"];
    public string Value { get; private set; }
    public Email(string email)
    {
         var valid=Valid(email);
         if (!valid)
         {
             throw new DomainException("Email con dominio invalido");
         }

         Value = email;

    }
    private Email(){}

    public bool Valid(string email)
    {
        foreach (var domain in _allowedDomains)
        {
            if (email.Contains(domain))
            {
                return true;
            }
        }

        return false;
    }
}