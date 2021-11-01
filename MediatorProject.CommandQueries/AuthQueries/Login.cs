using MediatorProject.Dtos;
using MediatR;

namespace MediatorProject.CommandQueries.AuthQueries
{
    public class Login : IRequest<UserDto>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
