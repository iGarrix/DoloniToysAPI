using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.RequestModels.Identity
{
    public class RefreshAuthorizateRequest
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
