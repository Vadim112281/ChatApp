using AuthService.Application.DTOs;
using AuthService.Domain.Models;
using AuthService.Infrastructure.Repositories;
using AutoMapper;
using ChatApp.Shared.Errors;
using ChatApp.Shared.Responses;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.Services;

public interface IUserService
{
    Task<Result<bool>> RegisterUserAsync(RegisterUserDto userDto);
    Task<Result<LoginUserDtoResult>> LoginUserAsync(LoginUserDto userDto);
}

public class UserService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    ITokenService tokenService,
    IUserRepository userRepository,
    IMapper mapper
) : IUserService
{
    public async Task<Result<bool>> RegisterUserAsync(RegisterUserDto userDto)
    {
        try
        {
            var user = mapper.Map<User>(userDto);

            var existingUser = await userManager.FindByEmailAsync(user.Email);

            if (existingUser != null)
            {
                return Result<bool>.ErrorResult(ErrorCodes.EmailAlreadyExists);
            }
            
            var existingUserName = await userRepository.CheckIfUserNameExists(user.UserName);

            if (existingUserName == true)
            {
                return Result<bool>.ErrorResult(ErrorCodes.UserNameAlreadyExists);
            }
            
            var result = await userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                return Result<bool>.SuccessResult(true);
            }

            var errors = result.Errors
                .Select(x => new ErrorItem(x.Code, x.Description))
                .ToList();

            return Result<bool>.ErrorsResult(errors);
        }
        catch (Exception ex)
        {
            return Result<bool>.ErrorResult(ErrorCodes.Unexpected(ex.Message));
        }
    }

    public async Task<Result<LoginUserDtoResult>> LoginUserAsync(LoginUserDto userDto)
    {
        var user = await userManager.FindByEmailAsync(userDto.Email);

        if (user == null)
        {
            return Result<LoginUserDtoResult>.ErrorResult(ErrorCodes.UserNotFound);
        }

        var signInResult = await signInManager
            .CheckPasswordSignInAsync(user, userDto.Password, false);

        if (!signInResult.Succeeded)
        {
            return Result<LoginUserDtoResult>.ErrorResult(ErrorCodes.InvalidCredentials);
        }

        return Result<LoginUserDtoResult>.SuccessResult(new LoginUserDtoResult
        {
            Email = user.Email,
            Token = tokenService.CreateToken(user)
        });
    }
}