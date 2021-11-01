using MediatorProject.CommandQueries.AuthQueries;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorProject.CommandHandlers.AuthOperations
{
    public class SignOutHandler : IRequestHandler<SignOut, bool>
    {
        private readonly IHttpContextAccessor _httpContext;

        public SignOutHandler(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public async Task<bool> Handle(SignOut request, CancellationToken cancellationToken)
        {
            await _httpContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return true;
        }
    }
}
