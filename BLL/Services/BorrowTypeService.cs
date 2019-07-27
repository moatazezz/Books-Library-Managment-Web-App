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
    public class BorrowTypeService : IBorrowTypeService
    {
        private IUnitOfWork<BorrowType> _uow;
        private IMapping _mapping;
        public BorrowTypeService(IUnitOfWork<BorrowType> UOW,IMapping mapping)
        {
            _uow = UOW;
            _mapping = mapping;
        }

        public IEnumerable<BorrowTypeVM> GetAllBorrowTypes()
        {
           

            return  _mapping.iMapper.Map<IEnumerable<BorrowType>, IEnumerable<BorrowTypeVM>>(_uow.GetRepoInstance().GetAll());

        }
        public BorrowTypeVM GetBorrowTypesById(int id)
        {
            return _mapping.iMapper.Map<BorrowTypeVM>(_uow.GetRepoInstance().GetById(id));
        }
        public void AddBorrowType(BorrowTypeVM BorrowType)
        {
            _uow.GetRepoInstance().Insert(_mapping.iMapper.Map<BorrowType>(BorrowType));
            _uow.SaveChanges();
        }
        public void EditBorrowType(BorrowTypeVM BorrowType)
        {
            _uow.GetRepoInstance().Update(_mapping.iMapper.Map<BorrowType>(BorrowType));
            _uow.SaveChanges();
        }
    }
}
