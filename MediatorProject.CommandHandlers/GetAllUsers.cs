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
    public class GetAllUsers : IRequestHandler<GetAllUsersQuery, IQueryable<UserDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetAllUsers(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IQueryable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllAsync();
            return _mapper.ProjectTo<UserDto>(users);
        }
    }
}
