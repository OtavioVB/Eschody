using Eschody.Domain.Contracts.Services.Token;
using Eschody.Domain.Models.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Eschody.Services.Token;

/// <summary>
/// Classe relacionado aos serviços de tokenização JWT Bearer
/// </summary>
public class TokenService : ITokenService
{
    /// <summary>
    /// Método para gerar token
    /// </summary>
    public string GenerateToken(User user)
    {
        string jwtKey;
        if (Environment.GetEnvironmentVariable("ESCHODY_JWT_BEARER_KEY") == null) throw new Exception("INTERNAL ERROR: JWT Bearer Key not implemented");
        else jwtKey = Environment.GetEnvironmentVariable("ESCHODY_JWT_BEARER_KEY")!.ToString();

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(jwtKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Nickname", user.Nickname!),
                new Claim("Role", user.Role!)
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    /// <summary>
    /// Método para fazer o refresh do JWT Bearer Token
    /// </summary>
    public string RefreshToken()
    {
        return "Necessário Implementar";
    }
}
