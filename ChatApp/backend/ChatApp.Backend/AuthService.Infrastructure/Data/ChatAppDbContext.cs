using AuthService.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Data;

public class ChatAppDbContext: IdentityDbContext<User>
{
    public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options ): base(options)
    {
    }
}