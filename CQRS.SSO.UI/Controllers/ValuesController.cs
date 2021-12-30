using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.SSO.UI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var result = new List<object> {
                new {name="rafi", surname="bayrak" },
                new {name="rafi2", surname="bayrak2" },
                new {name="rafi3", surname="bayrak3" },
                new {name="rafi4", surname="bayrak4" },
                new {name="rafi5", surname="bayrak5" },
            };
            return Ok(result);
        }
    }
}
