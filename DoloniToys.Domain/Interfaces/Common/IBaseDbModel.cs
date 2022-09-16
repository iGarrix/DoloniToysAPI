using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Interfaces.Common
{
    public interface BaseDbModel<Type>
    {
        Type Id { get; set; }
        DateTime Create { get; set; }
    }
}
