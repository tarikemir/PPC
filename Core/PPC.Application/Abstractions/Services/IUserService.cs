using System.Security.Claims;
using PPC.Application.DTOs.User;
using PPC.Domain.Identity;

namespace PPC.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUserModel user);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDateSeconds);
        Task<Guid> GetIdFromClaim(Claim claim);
    }
}
