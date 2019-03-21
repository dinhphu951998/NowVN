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
        T Add(T entity);
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

        public T Add(T entity)
        {
            _context.Add(entity);
            SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            SaveChanges();
            //((Microsoft.EntityFrameworkCore.Infrastructure.IObjectContextAdapter)dbContext).ObjectContext.Detach(entity);
        }

        private void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }catch(NowVNException ex)
            {
                throw new NowVNException(ex);
            }
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
