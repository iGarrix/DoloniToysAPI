using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Interfaces.Common
{
    public interface IBaseRepository<TEntity, TIdType>
    {
        public IQueryable<TEntity> Items { get; }
        public bool Delete(TIdType id);
        public TEntity Add(TEntity entity);
        public bool Change(TEntity entity);
        public TEntity GetById(TIdType id);
    }
}
