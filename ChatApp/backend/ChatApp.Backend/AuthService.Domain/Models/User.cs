
using Microsoft.AspNetCore.Identity;

namespace AuthService.Domain.Models;

public class User: IdentityUser
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string? AvatarUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsOnline { get; set; } = false;
}