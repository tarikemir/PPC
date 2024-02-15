using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.Features.Queries.Link.GetUserLinks
{
    public class GetUserLinksQueryRequest : IRequest<GetUserLinksQueryResponse>
    {
        public Guid UserId { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
