﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.Repositories.Link
{
    public interface ILinkWriteRepository : IReadRepository<PPC.Domain.Entities.Link, Guid>
    {
    }
}
