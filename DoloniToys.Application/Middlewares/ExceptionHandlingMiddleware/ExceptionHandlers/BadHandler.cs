using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Middlewares.ExceptionHandlingMiddleware.ExceptionHandlers
{
    public class BadHandler : Exception
    {
        public BadHandler() : base("Handle bad request, try again") { }
        public BadHandler(string message) : base(message) { }
    }
}
