using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
 
        public interface IRepository<TEntity> where TEntity : class
        {
            IEnumerable<TEntity> GetAll();
            TEntity GetById(object id);
            void Insert(TEntity entity);
            void Update(TEntity entity);
            void Delete(object id);
            
        }
    }

