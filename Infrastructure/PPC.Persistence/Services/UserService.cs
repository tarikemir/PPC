﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using PPC.Application.Abstractions.Services;
using PPC.Application.DTOs.User;
using PPC.Application.Exceptions;
using PPC.Domain.Identity;

namespace PPC.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUserModel model)
        {
            Guid guid = Guid.NewGuid();
            IdentityResult identityResult = await _userManager.CreateAsync(new()
            {
                Id = guid,
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.Username,
                Email = model.Email,
                ProfilePicture = model.ProfilePicture,
                CreatedByUserId = guid.ToString()
            }, model.Password);

            CreateUserResponse response = new() { Succeeded = identityResult.Succeeded };

            if (identityResult.Succeeded)
                response.Message = "Kullanıcı Başarıyla Oluşturulmuştur";
            else
                foreach (var error in identityResult.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }

        public async Task<Guid> GetIdFromClaim(Claim claim)
        {
            return (await _userManager.GetUsersForClaimAsync(claim)).First().Id;
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDateSeconds)
        {
            if (user is not null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDateSeconds);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new NotFoundUserException();
            }
        }
    }
}
