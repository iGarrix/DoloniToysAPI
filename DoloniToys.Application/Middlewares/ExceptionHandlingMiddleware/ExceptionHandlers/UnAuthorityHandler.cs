using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Middlewares.ExceptionHandlingMiddleware.ExceptionHandlers
{
    public class UnAuthorityHandler : Exception
    {
        public UnAuthorityHandler() : base("Handle un authority request, try again") { }
        public UnAuthorityHandler(string message) : base(message) { }
    }
}
