using AutoMapper;
using CQRS.Business.CommandQueries.UserQueries;
using CQRS.Data.Dtos;
using CQRS.Data.Models;

namespace CQRS.Business.CommandHandlers.Profiles
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
