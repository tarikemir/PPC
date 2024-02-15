using MediatR;
using PPC.Application.Abstractions.Services;
using PPC.Application.Exceptions;
using PPC.Application.Repositories;
using PPC.Application.Repositories.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.Features.Commands.Link.CreateLink
{
    public class CreateLinkCommandHandler : IRequestHandler< CreateLinkCommandRequest, CreateLinkCommandResponse>
    {
        private readonly ILinkWriteRepository _linkWriteRepository;
        private readonly IUserService _userService;

        public CreateLinkCommandHandler(ILinkWriteRepository linkWriteRepository, IUserService userService)
        {
            _linkWriteRepository = linkWriteRepository;
            _userService = userService;
        }
        public async Task<CreateLinkCommandResponse> Handle(CreateLinkCommandRequest request, CancellationToken cancellationToken)
        {
            Guid userId = await _userService.GetIdFromClaim(request.Claim!);

            if (userId != Guid.Empty)
            {
                PPC.Domain.Entities.Link link = new()
                {
                    OriginalUrl = request.OriginalUrl,
                    ShortenedUrl = request.ShortenedUrl, // There should be an algorithms implemented beforehand for the shortened url.
                    CreatedByUserId = userId.ToString(),
                    ClickCount = 0
                };
                await _linkWriteRepository.AddAsync(link);
                await _linkWriteRepository.SaveAsync();

                return new CreateLinkCommandResponse()
                {
                    StatusCode = 201,
                    LinkId = link.Id.ToString()
                };
            }
            else throw new Exception("User needs to be logged in!");
        }
    }
}
