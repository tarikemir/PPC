using PPC.Application.Repositories;
using PPC.Application.Repositories.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.Features.Queries.Link.GetUserLinks
{
    public class GetUserLinksQueryHandler
    {
        private readonly ILinkReadRepository _linkReadRepository;

        public GetUserLinksQueryHandler(ILinkReadRepository linkReadRepository)
        {
            _linkReadRepository = linkReadRepository;
        }

        public Task<GetUserLinksQueryResponse> Handle(GetUserLinksQueryRequest request, CancellationToken cancellationToken)
        {
            var links = _linkReadRepository.GetWhere(c => c.UserId == request.UserId && c.IsDeleted == false).Select(c => new
            {
                c.Id,
                c.OriginalUrl,
                c.ShortenedUrl,
                c.ClickCount,
                c.UserId,
                c.CreatedOn,
                c.ModifiedOn
            }).Skip(request.Page * request.Size).Take(request.Size);

            return Task.FromResult<GetUserLinksQueryResponse>(new()
            {
                Links = links,
                TotalCount = links.Count()
            });
        }
    }
}
