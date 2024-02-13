namespace PPC.Application.Repositories.Link
{
    public interface ILinkReadRepository : IReadRepository<PPC.Domain.Entities.Link, Guid>
    {
        IQueryable<PPC.Domain.Entities.Link> GetAllByUserId( string id);
    }
}
