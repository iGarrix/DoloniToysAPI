using DoloniToys.Domain.Interfaces.Common;
using DoloniToys.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Dtos.Identity
{
    public class UserDto : BaseDtoModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
