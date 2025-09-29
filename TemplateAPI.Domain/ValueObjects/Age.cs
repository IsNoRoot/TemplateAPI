using TemplateAPI.Domain.Exceptions;

namespace TemplateAPI.Domain.ValueObjects;

public class Age
{
    public int Value { get; private set; }
    public Age(int age)
    {
        Valid(age);
        Value = age;
    }

    private Age()
    {
        
    }

    private void Valid(int age)
    {
        if (age < 0 || age > 100)
        {
            throw new DomainException("Edad invalida, el rango es de 0 a 100");
        }
    }
}