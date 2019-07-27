using AutoMapper;
using BLL.Mapping;
using BLL.VM;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class Service<T,TVM> : IService<T,TVM> where T : class where TVM : class
    {
        protected IUnitOfWork<T> _uow  ;
        protected IMapping _mapping;
        public Service(IUnitOfWork<T> UOW,IMapping mapping)
        {
            _uow = UOW;
            _mapping = mapping;
        }

        public IEnumerable<TVM> GetAll()
        {
           

            return  _mapping.iMapper.Map<IEnumerable<T>, IEnumerable<TVM>>(_uow.GetRepoInstance().GetAll());

        }
        public void Add(TVM TVM)
        {
            _uow.GetRepoInstance().Insert(_mapping.iMapper.Map<T>(TVM));
            _uow.SaveChanges();
        }

        public void Update(TVM TVM)
        {
            _uow.GetRepoInstance().Update(_mapping.iMapper.Map<T>(TVM));
            _uow.SaveChanges();
        }
      public  TVM GetById(int id)
        {
            return _mapping.iMapper.Map<TVM>(_uow.GetRepoInstance().GetById(id));

        }
        
    }
}
