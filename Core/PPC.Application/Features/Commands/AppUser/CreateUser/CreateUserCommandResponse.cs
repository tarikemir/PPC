using MediatR;
using PPC.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandResponse : IRequest<CreateUserCommandRequest>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public static explicit operator CreateUserCommandResponse(CreateUserResponse response) => new()
        {
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}
