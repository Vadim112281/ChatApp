namespace AuthService.Domain.Models;

public class JwtSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SigningKey { get; set; }
    public int TokenExpirationDays { get; set; }
}