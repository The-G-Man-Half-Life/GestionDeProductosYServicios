using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using GestionDeProductosYServicios.Models;
using Microsoft.IdentityModel.Tokens;

namespace GestionDeProductosYServicios.Configurations;
public class Utilities
{
    public string EncryptpSHA256(string input)
    {
        using (SHA256 SHA256HASH = SHA256.Create())
        {
            byte[] bytes = SHA256HASH.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i<bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
    public string GenerateJWTToken(Client Client)
    {
        var Claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, Client.Client_id.ToString()),
            new Claim(ClaimTypes.Name, Client.Client_name.ToString())
        };

        var JWT_KEY = Environment.GetEnvironmentVariable("JWT_KEY");
        var JWT_ISSUER = Environment.GetEnvironmentVariable("JWT_ISSUER");
        var JWT_AUDIENCE = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
        var JWT_EXPIRES_IN = Environment.GetEnvironmentVariable("JWT_EXPIRES_IN");

        var Entry = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT_KEY));

        var credentials = new SigningCredentials(Entry, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: JWT_ISSUER,
            audience: JWT_AUDIENCE,
            claims: Claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(JWT_EXPIRES_IN)),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}