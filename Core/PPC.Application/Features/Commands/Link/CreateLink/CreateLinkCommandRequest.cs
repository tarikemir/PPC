using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.Features.Commands.Link.CreateLink
{
    public class CreateLinkCommandRequest : IRequest<CreateLinkCommandResponse>
    {
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        
        public Claim? Claim { get; set; }
    }
}
