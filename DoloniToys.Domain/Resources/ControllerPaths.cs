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

    public static class ProductPaths
    {
        public const string Add = "ADD_PRODUCT";
        public const string GetAll = "GET_ALL";
        public const string Get = "GET_BY_ARTICLE";
        public const string GetFilter = "GET_PRODUCTS_BY_CATEGORY";
        public const string Change = "CHANGE_PRODUCT";
        public const string Remove = "REMOVE_PRODUCT";
    }

    public static class QuestionPaths
    {
        public const string Add = "ADD_QUESTION";
        public const string GetAll = "GET_ALL";
    }
}
