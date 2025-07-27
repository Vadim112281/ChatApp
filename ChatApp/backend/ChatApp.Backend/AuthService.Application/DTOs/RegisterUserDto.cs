namespace AuthService.Application.DTOs;

public record RegisterUserDto
{
    public string Email { get; init; }
    public string UserName { get; init; }
    public string Password { get; init; }
}