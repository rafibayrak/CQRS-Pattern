using AutoMapper;
using MediatorProject.CommandQueries.UserQueries;
using MediatorProject.Core.IRepositories;
using MediatorProject.Dtos;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorProject.CommandHandlers.UserOperations
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IQueryable<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUsersHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IQueryable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.ProjectTo<UserDto>(users);
        }
    }
}
