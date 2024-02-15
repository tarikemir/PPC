using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.Features.Commands.Link.UpdateLink
{
    public class UpdateLinkCommandRequest : IRequest<UpdateLinkCommandResponse>
    {
        public string Id { get; set; }
        public string OriginalUrl { get; set; }

        public Claim? Claim { get; set; }
    }
}
