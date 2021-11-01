using AutoMapper;
using MediatorProject.CommandQueries.UserQueries;
using MediatorProject.Dtos;
using MediatorProject.Models;

namespace MediatorProject.CommandHandlers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<CreateUserQuery, User>();
        }
    }
}
