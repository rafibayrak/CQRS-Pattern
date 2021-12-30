using AutoMapper;
using CQRS.DataAccess.IRepositories;
using CQRS.Data.Dtos;
using CQRS.Data.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Business.CommandQueries.UserQueries;

namespace CQRS.Business.CommandHandlers.UserOperations
{
    public class CreateUserHandler : IRequestHandler<CreateUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserQuery request, CancellationToken cancellationToken)
        {
            var userMap = _mapper.Map<User>(request);
            var user = await _userRepository.AddAsync(userMap);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
