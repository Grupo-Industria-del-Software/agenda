using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class User : Entity
{
    [StringLength(50)]
    public string FirstName { get; set; }
    [StringLength(50)]
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    
    public string Password { get; set; }

    public User(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
}