using Microsoft.EntityFrameworkCore;
using NowVN.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Framework.BaseRepository
{
    public interface IBaseRepository <T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T Find(int Id);

    }

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected NowVNSimulatorContext _context { get; set; }

        public BaseRepository(NowVNSimulatorContext dbContext)
        {
            this._context = dbContext;
        }

        public IQueryable<T> Get(Func<T, bool> predicate)
        {
            var result = _context.Set<T>().Where(predicate);
            return result.AsQueryable();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            //((Microsoft.EntityFrameworkCore.Infrastructure.IObjectContextAdapter)dbContext).ObjectContext.Detach(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public virtual T Find(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
