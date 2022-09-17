using DoloniToys.Domain.Interfaces.Common;
using DoloniToys.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Infrastructure.Repositories.Common
{
    public class BaseRepository<TEntity, TIdType> : IBaseRepository<TEntity, TIdType> where TEntity : class, IBaseDbModel<TIdType>
    {
        private readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> Items => _context.Set<TEntity>().AsQueryable();

        public TEntity Add(TEntity entity)
        {
            try
            {
                var result = _context.Add<TEntity>(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Change(TEntity element)
        {
            try
            {
                _context.Update<TEntity>(element);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(TIdType id)
        {
            try
            {
                var item = _context.Set<TEntity>().Find(id);
                if (item is not null)
                {
                    _context.Set<TEntity>().Remove(item);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TEntity GetById(TIdType id)
        {
            try
            {
                var item = _context.Set<TEntity>().Find(id);
                return item;
            }
            catch (Exception)
            {
                throw new Exception("Entity is null");
            }
        }
    }
}
