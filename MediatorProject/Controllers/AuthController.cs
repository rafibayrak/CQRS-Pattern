using MediatorProject.CommandQueries.AuthQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatorProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(Login login)
        {
            var result = await _mediator.Send(login);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            var result = await _mediator.Send(new SignOut());
            if (result == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
