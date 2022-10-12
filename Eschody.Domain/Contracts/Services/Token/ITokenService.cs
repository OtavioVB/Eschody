using Eschody.Domain.Models.DTOs;

namespace Eschody.Domain.Contracts.Services.Token;

public interface ITokenService
{
    public string GenerateToken(User user);
    public string RefreshToken();
}
