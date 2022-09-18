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
    }
}
