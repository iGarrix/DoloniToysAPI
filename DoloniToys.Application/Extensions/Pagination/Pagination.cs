using AutoMapper;
using DoloniToys.Application.Extensions.Identity;
using DoloniToys.Application.Middlewares.ExceptionHandlingMiddleware.ExceptionHandlers;
using DoloniToys.Domain.Interfaces.Pagination.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Extensions.Pagination
{
    public static class Pagination
    {
        public static PaginationResponse<TData> Paginate<TData>(PaginationParams<TData> paginationParams)
        {
            int total = paginationParams.TData.Count() > 0 ? paginationParams.TData.Count() / paginationParams.Take : throw new NotFoundHandler();
            var round = Decimal.Divide(paginationParams.TData.Count(), paginationParams.Take);
            if (round > total)
            {
                ++total;
            }

            if (paginationParams.CurrentPage == 0 || paginationParams.CurrentPage > total)
            {
                throw new Exception("Current page is not valid, because she don't cannot be overflowed");
            }

            List<TData> paginateData = paginationParams.TData
                    .Skip((paginationParams.CurrentPage - 1) * paginationParams.Take)
                    .Take(paginationParams.Take)
                    .Select(x => x)
                    .ToList();


            return new PaginationResponse<TData>()
            {
                Pageables = paginateData is not null ? paginateData : throw new NotFoundHandler("Data empty"),
                TotalObj = paginationParams.TData.Count(),
                Total = total,
                NextPage = paginationParams.CurrentPage < total ? paginationParams.CurrentPage + 1 : -1,
                PrevPage = paginationParams.CurrentPage <= 1 ? -1 : paginationParams.CurrentPage - 1,
                Takes = paginationParams.Take,
                CurrentPage = paginationParams.CurrentPage,
            };
        }

        public static PaginationResponse<TDataDto> PaginateToDtos<TData, TDataDto>(PaginationParams<TData> paginationParams, IMapper mapper)
        {
            int total = paginationParams.TData.Count() > 0 ? paginationParams.TData.Count() / paginationParams.Take : throw new NotFoundHandler();
            var round = Decimal.Divide(paginationParams.TData.Count(), paginationParams.Take);
            if (round > total)
            {
                ++total;
            }

            if (paginationParams.CurrentPage == 0 || paginationParams.CurrentPage > total)
            {
                throw new Exception("Current page is not valid, because she don't cannot be overflowed");
            }

            List<TData> paginateData = paginationParams.TData
                    .Skip((paginationParams.CurrentPage - 1) * paginationParams.Take)
                    .Take(paginationParams.Take)
                    .Select(x => x)
                    .ToList();


            return new PaginationResponse<TDataDto>()
            {
                Pageables = paginateData is not null ? paginateData.ToListDto<TData, TDataDto>(mapper) : throw new NotFoundHandler("Data empty"),
                TotalObj = paginationParams.TData.Count(),
                Total = total,
                NextPage = paginationParams.CurrentPage < total ? paginationParams.CurrentPage + 1 : -1,
                PrevPage = paginationParams.CurrentPage <= 1 ? -1 : paginationParams.CurrentPage - 1,
                Takes = paginationParams.Take,
                CurrentPage = paginationParams.CurrentPage,
            };
        }
    }
}
