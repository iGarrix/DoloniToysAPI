using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Middlewares.ExceptionHandlingMiddleware.ExceptionHandlers
{
    public class NotFoundHandler : Exception
    {
        public NotFoundHandler() : base("Handle not found data, try again") { }

        public NotFoundHandler(string message) : base(message) { }
    }
}
