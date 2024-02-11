using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.DTOs
{
    public class AuthenticationLoginResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<AuthenticationLoginResponseError> Errors { get; set; }
    }

    public class AuthenticationLoginResponseError
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
