using PPC.Application.Abstractions.Services;
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
        private readonly IUserService _userService;

        public GetUserLinksQueryHandler(ILinkReadRepository linkReadRepository, IUserService userService)
        {
            _linkReadRepository = linkReadRepository;
            _userService = userService;
        }

        public async Task<GetUserLinksQueryResponse> Handle(GetUserLinksQueryRequest request, CancellationToken cancellationToken)
        {
            Guid userId = await _userService.GetIdFromClaim(request.Claim!);

            var links = _linkReadRepository.GetWhere(c => c.UserId == userId && c.IsDeleted == false).Select(c => new
            {
                c.Id,
                c.OriginalUrl,
                c.ShortenedUrl,
                c.ClickCount,
                c.UserId,
                c.CreatedOn,
                c.ModifiedOn
            }).Skip(request.Page * request.Size).Take(request.Size);

            return await Task.FromResult<GetUserLinksQueryResponse>(new()
            {
                Links = links,
                TotalCount = links.Count()
            });
        }
    }
}
