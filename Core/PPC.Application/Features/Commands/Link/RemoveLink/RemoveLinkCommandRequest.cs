using MediatR;
using System.Security.Claims;

namespace PPC.Application.Features.Commands.Link.RemoveLink
{
    public class RemoveLinkCommandRequest : IRequest<RemoveLinkCommandResponse>
    {
        public string Id { get; set; }
        public Claim? Claim { get; set; }
    }
}
