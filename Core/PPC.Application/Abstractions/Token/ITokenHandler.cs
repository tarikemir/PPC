using PPC.Domain.Identity;

namespace PPC.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken( int second, AppUser user );
        string CreateRefreshToken();
    }
}
