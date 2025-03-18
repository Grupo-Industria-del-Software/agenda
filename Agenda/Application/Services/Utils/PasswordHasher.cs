using Application.Interfaces.Utils;

namespace Application.Services.Utils;

public class PasswordHasher :  IPasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string hashedPassword, string password)
    {
        
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}