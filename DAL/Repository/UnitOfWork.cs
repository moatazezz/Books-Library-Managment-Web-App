using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
  public  class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        private LibraryContext _context;

        private IRepository<TEntity> _repository ;
        public UnitOfWork(LibraryContext dbContext, IRepository<TEntity> repository) 
        {
            _context = dbContext;
            _repository = repository;
        }

        public IRepository<TEntity> GetRepoInstance() 
        {
            return _repository;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
