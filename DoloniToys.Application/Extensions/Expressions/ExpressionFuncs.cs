using DoloniToys.Domain.Models.DbModels;
using DoloniToys.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Extensions.Expressions
{
    public static class ExpressionFuncs
    {
        public static IOrderedQueryable<Product> Expression(this IQueryable<Product> list, string filterParam)
        {
            switch (filterParam)
            {
                case ExpressionTypes.FilterNameOrder:
                    {
                        return list.OrderBy(x => x.Title);
                    }
                case ExpressionTypes.FilterNameOrderByDescending:
                    {
                        return list.OrderByDescending(x => x.Title);
                    }
                case ExpressionTypes.FilterRatingOrder:
                    {
                        return list.OrderBy(x => x.Rating);
                    }
                case ExpressionTypes.FilterRatingOrderByDescending:
                    {
                        return list.OrderByDescending(x => x.Rating);
                    }
                default:
                    return list.OrderByDescending(x => x.Create);
            }
        }

        public static IQueryable<Product> SelectEco(this IQueryable<Product> list, bool getEco)
        {
            if (getEco)
            {
                return list.Where(w => w.Article.ToLower().Contains("eco"));
            }
            return list.Where(w => !w.Article.ToLower().Contains("eco"));
        }

        public static IQueryable<Category> SelectEco(this IQueryable<Category> categories, string getEco = "standart")
        {
            if (getEco == "eco")
            {
                return categories.Where(w => w.Title.ToLower().Contains("eco"));
            }
            if (getEco == "standart")
            {
                return categories.Where(w => !w.Title.ToLower().Contains("eco"));
            }
            return categories;
            //return categories.Select(x => new Category()
            //{
            //    Id = x.Id,
            //    Create = x.Create,
            //    Image = x.Image,
            //    Products = x.Products,
            //    Rating = x.Rating,
            //    Title = "Eco " + x.Title,
            //    UaTitle = "Еко " + x.UaTitle,
            //});
        }
    }
}
