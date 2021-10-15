using MediatorProject.Dtos;
using MediatR;

namespace MediatorProject.CommandQueries
{
    public class CreateUserQuery : IRequest<UserDto>
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
