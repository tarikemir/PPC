using MediatR;
using PPC.Application.Abstractions.Services.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        private readonly IAuthentication _authentication;

        public RefreshTokenLoginCommandHandler(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken) => new RefreshTokenLoginCommandResponse()
        {
            Token = await _authentication.RefreshLoginAsync(request.RefreshToken),
        };
    }
}
