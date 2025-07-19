
using Microsoft.AspNetCore.Identity;

namespace AuthService.Domain.Models;

public class User: IdentityUser
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AvatarUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsOnline { get; set; }
}