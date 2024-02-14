using MediatR;
using PPC.Application.Abstractions.Services.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthentication _authentication;

        public LoginUserCommandHandler(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken) =>
            new() { Token = await _authentication.LoginAsync(request.Email, request.Password, 160) };

    }
}
