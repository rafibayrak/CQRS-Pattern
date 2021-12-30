using AutoMapper;
using CQRS.Business.CommandQueries.AuthQueries;
using CQRS.Data.Dtos;
using CQRS.DataAccess.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Business.CommandHandlers.AuthOperations
{
    public class SignInHandler : IRequestHandler<Login, UserDto>
    {
        private IUserRepository _userRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public SignInHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(Login request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.UserName == request.UserName || x.Email == request.Email);
            if (user == null)
            {
                return null;
            }

            if (user.Password != request.Password)
            {
                return null;
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim("Email", user.Email),
                    new Claim("UserName", user.UserName),
                    new Claim(ClaimTypes.Role, "Administrator"),
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true
            };
            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);
            return _mapper.Map<UserDto>(user);
        }
    }
}
