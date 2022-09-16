using DoloniToys.Domain.Dtos.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.ResponseModel.Identity
{
    public class AuthorizateResponse
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public UserDto Profile { get; set; }
    }
}
