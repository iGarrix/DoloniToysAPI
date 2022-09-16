using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Models.Common
{
    abstract public class BaseDbModel<Type> : Interfaces.Common.BaseDbModel<Type>
    {
        [Key]
        public Type Id { get; set; }
        public DateTime Create { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    }
}
