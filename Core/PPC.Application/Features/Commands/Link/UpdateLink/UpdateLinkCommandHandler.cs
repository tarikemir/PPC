using MediatR;
using PPC.Application.Abstractions.Services;
using PPC.Application.Exceptions;
using PPC.Application.Features.Commands.Link.RemoveLink;
using PPC.Application.Repositories.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.Features.Commands.Link.UpdateLink
{
    public class UpdateLinkCommandHandler : IRequestHandler< UpdateLinkCommandRequest, UpdateLinkCommandResponse>
    {
        private readonly ILinkReadRepository _linkReadRepository;
        private readonly ILinkWriteRepository _linkWriteRepository;
        private readonly IUserService _userService;

        public UpdateLinkCommandHandler(ILinkReadRepository linkReadRepository, ILinkWriteRepository linkWriteRepository, IUserService userService)
        {
            _linkReadRepository = linkReadRepository;
            _linkWriteRepository = linkWriteRepository;
            _userService = userService;
        }

        public async Task<UpdateLinkCommandResponse> Handle(UpdateLinkCommandRequest request, CancellationToken cancellationToken)
        {
            PPC.Domain.Entities.Link? link = await _linkReadRepository.GetByIdAsync(request.Id);

            if (link is null) throw new NotFoundException("Link");

            if (!link.IsDeleted)
            {
                Guid userId = await _userService.GetIdFromClaim(request.Claim!);
                if (link.UserId == userId)
                {
                    link.OriginalUrl = request.OriginalUrl;// ?? string.Empty;
                    link.ModifiedByUserId = userId.ToString();
                    link.ModifiedOn = DateTimeOffset.UtcNow;

                    await _linkWriteRepository.SaveAsync();

                    return new()
                    {
                        Succeeded = true
                    };
                }
                else throw new NotBelongsToUserException("Link doesn't belong to the logged in user.");
            }

            return new()
            {
                Succeeded = true
            };
        }
    }
}
