using Domain.Entities;

namespace Application.Interfaces.Jwt;

public interface IJwtService
{
    public string GenerateJwtToken(User user);
}