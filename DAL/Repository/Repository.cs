using DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
 
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
        {
            private LibraryContext _context;
            private DbSet<TEntity> dbSet;

            public Repository(LibraryContext dbContext)
            {
                _context = dbContext;
                dbSet = _context.Set<TEntity>();
            }
        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
        public TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }
        public void Insert(TEntity obj)
        {
                dbSet.Add(obj);
        }
        public void Update(TEntity obj)
        {
            dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            TEntity existing = dbSet.Find(id);
            dbSet.Remove(existing);
        }
        

    }
}
