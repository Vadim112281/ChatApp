namespace AuthService.Application.DTOs;

public record LoginUserDto
{
    public string Email { get; init; }
    public string Password { get; init; }
}