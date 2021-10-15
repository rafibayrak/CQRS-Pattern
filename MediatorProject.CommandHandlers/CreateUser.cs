using AutoMapper;
using MediatorProject.CommandQueries;
using MediatorProject.Core.IServices;
using MediatorProject.Dtos;
using MediatorProject.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorProject.CommandHandlers
{
    public class CreateUser : IRequestHandler<CreateUserQuery, UserDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateUser(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserQuery request, CancellationToken cancellationToken)
        {
            var userMap = _mapper.Map<User>(request);
            var user = await _userService.AddAsync(userMap);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
