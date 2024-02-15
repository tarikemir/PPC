using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.Features.Queries.Link.GetUserLinks
{
    public class GetUserLinksQueryResponse
    {
        public int TotalCount { get; set; }
        public object Links { get; set; }
    }
}
