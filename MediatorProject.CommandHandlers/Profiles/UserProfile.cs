using AutoMapper;
using MediatorProject.CommandQueries;
using MediatorProject.Dtos;
using MediatorProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
