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
        void Update(T entity, T updatedEntity);
        IEnumerable<T> GetAll();
        T Find(int Id);

    }

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected NowVNSimulatorContext dbContext { get; set; }

        public BaseRepository(NowVNSimulatorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<T> Get(Func<T, bool> predicate)
        {
            var result = dbContext.Set<T>().Where(predicate);
            return result.AsQueryable();
        }

        public T Add(T entity)
        {
            dbContext.Add(entity);
            SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            SaveChanges();
        }

        public virtual void Update(T entity, T updatedEntity)
        {
            var attachedEntry = dbContext.Entry(entity); 

            attachedEntry.CurrentValues.SetValues(updatedEntity);
            SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                dbContext.SaveChanges();
            }catch(NowVNException ex)
            {
                throw new NowVNException(ex);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().AsEnumerable();
        }

        public virtual T Find(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
