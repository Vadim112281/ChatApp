using AuthService.Domain.Models;
using AuthService.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories;

public interface IUserRepository
{
    Task<bool> CheckIfUserNameExists(string userName);
}

public class UserRepository(
    ChatAppDbContext dbContext
) : IUserRepository
{
    public async Task<bool> CheckIfUserNameExists(string userName)
    {
        var result = await dbContext.Users
            .AnyAsync(x => x.UserName == userName);

        return result;
    }
}  
