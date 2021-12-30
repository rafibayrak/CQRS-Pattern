using CQRS.Business.CommandQueries.UserQueries;
using CQRS.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var query = await _mediator.Send(new GetAllUsersQuery());
            return Ok(query);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserQuery user)
        {
            var query = await _mediator.Send(user);
            return Ok(query);
        }
    }
}
