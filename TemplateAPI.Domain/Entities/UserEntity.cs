using TemplateAPI.Domain.ValueObjects;

namespace TemplateAPI.Domain.Entities;

public class UserEntity
{
    public UserEntity(string name,string firstName,string lastName,int age,string email,string userName,string password,int id=0)
    {
        Id = id;
        Name = name;
        FirstName = firstName;
        LastName = lastName;
        Age = new Age(age);
        Email = new Email(email);
        UserName = userName;
        Password = new Password(password);
    }
    private UserEntity() { }

    
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Age Age { get; set; }
    public Email Email { get; set; }
    public string UserName { get; set; } = string.Empty;
    public Password Password { get; set; }
}