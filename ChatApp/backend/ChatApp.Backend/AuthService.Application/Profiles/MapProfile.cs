using AuthService.Application.DTOs;
using AuthService.Domain.Models;
using AutoMapper;

namespace AuthService.Application.Profiles;

public class MapProfile: Profile
{
    public MapProfile()
    {
        CreateMap<RegisterUserDto, User>();
    }
}