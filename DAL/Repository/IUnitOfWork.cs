using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
   

        public interface IUnitOfWork<TEntity> where TEntity : class
        {
            
            IRepository<TEntity> GetRepoInstance();
            
             void SaveChanges();
           
        }
    }


