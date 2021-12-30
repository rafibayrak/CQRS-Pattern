using CQRS.Data.Dtos;
using MediatR;

namespace CQRS.Business.CommandQueries.UserQueries
{
    public class CreateUserQuery : IRequest<UserDto>
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
