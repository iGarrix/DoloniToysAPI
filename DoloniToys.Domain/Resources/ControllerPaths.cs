using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Resources
{
    public static class AccountPaths
    {
        public const string GetAuthorize = "GET_AUTHORIZE";
        public const string LogInAuthorize = "LOGIN_AUTHORIZE";
        public const string RefreshTokenAuthorize = "REFRESH_TOKEN_AUTHORIZE";
    }

    public static class CategoryPaths
    {
        public const string Add = "ADD_CATEGORY";
        public const string GetAll = "GET_ALL";
        public const string Change = "CHANGE_CATEGORY";
        public const string Remove = "REMOVE_CATEGORY"; 
    }
}
