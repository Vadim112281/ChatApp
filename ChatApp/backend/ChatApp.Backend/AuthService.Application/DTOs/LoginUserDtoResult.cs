namespace AuthService.Application.DTOs;

public record LoginUserDtoResult
{
    public string Email { get; init; }
    public string Token { get; init; }
}