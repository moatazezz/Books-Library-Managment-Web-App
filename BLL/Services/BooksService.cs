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
    public class BooksService : IBooksService
    {
        private IUnitOfWork<Books> _uow;
        private IMapping _mapping;
        public BooksService(IUnitOfWork<Books> UOW,IMapping mapping)
        {
            _uow = UOW;
            _mapping = mapping;
        }

        public IEnumerable<BooksVM> GetAllBooks()
        {
           

            return  _mapping.iMapper.Map<IEnumerable<Books>, IEnumerable<BooksVM>>(_uow.GetRepoInstance().GetAll());

        }
        public void AddBook(BooksVM book)
        {
            _uow.GetRepoInstance().Insert(_mapping.iMapper.Map<Books>(book));
            _uow.SaveChanges();
        }
        public void EditBook(BooksVM book)
        {
            _uow.GetRepoInstance().Update(_mapping.iMapper.Map<Books>(book));
            _uow.SaveChanges();
        }
    public  BooksVM GetBookById(int id)
        {
            return _mapping.iMapper.Map<BooksVM>(_uow.GetRepoInstance().GetById(id));
        }
    }
}
