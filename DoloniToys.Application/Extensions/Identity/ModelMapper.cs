using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Extensions.Identity
{
    public static class ModelMapper
    {
        public static TDest ToDto<TSource, TDest>(this TSource tSourse, IMapper mapper)
        {
            return mapper.Map<TSource, TDest>(tSourse);
        }
        public static IEnumerable<TDest> ToListDto<TSource, TDest>(this List<TSource> tSourses, IMapper mapper)
        {
            foreach (var item in tSourses)
            {
                yield return mapper.Map<TSource, TDest>(item);
            }
        }
    }
}
