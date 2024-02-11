using PPC.Application.DTOs;

namespace PPC.Application.Abstractions.Services.Authentications
{
    public interface IAuthentication
    {
        Task<DTOs.Token> LoginAsync(string email, string password, int accessTokenLifeTime);
        Task<DTOs.Token> RefreshLoginAsync(string refreshtoken);
    }
}
