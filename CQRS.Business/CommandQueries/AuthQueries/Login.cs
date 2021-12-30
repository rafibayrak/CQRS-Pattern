using CQRS.Data.Dtos;
using MediatR;

namespace CQRS.Business.CommandQueries.AuthQueries
{
    public class Login : IRequest<UserDto>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
