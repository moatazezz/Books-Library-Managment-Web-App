using BLL.Mapping;
using BLL.VM;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
  public  class BorrowReturnActionService : Service<BorrowReturnAction, BorrowReturnActionVM>,IBorrowReturnActionService
    {
        private IBooksService _bookservice;
        public BorrowReturnActionService(IUnitOfWork<BorrowReturnAction> UOW, IMapping mapping, IBooksService bookservice) :base(UOW, mapping)
        {
            _bookservice = bookservice;
        }
      public  IEnumerable<BorrowReturnActionVM> GetBorrowedBooks()
        {
        return _mapping.iMapper.Map<IEnumerable<BorrowReturnActionVM>>
        (_uow.GetRepoInstance().GetAll().Where(b => b.BorrowDate > DateTime.MinValue
        & b.ReturnDate == DateTime.MinValue));
        }
        public IEnumerable<BooksVM> GetAvilableBooks()
        {
            return _mapping.iMapper.Map<IEnumerable<BooksVM>>
           (_bookservice.GetAllBooks().
           Where(b => b.CopiesNumber > GetBorrowedBooks().Where(book=> book.BookId ==b.id).Count()));
        }
      public  IEnumerable<BooksVM> GetAvilableBooksById(int BookId)
        {
          return  GetAvilableBooks().Where(b=>b.id == BookId);
        }
        public int GetNumberOfAvailableCopies(int BookId)
        {
         return   GetAvilableBooks().Where(b => b.id == BookId).FirstOrDefault().CopiesNumber - GetBorrowedBooks().Where(b => b.BookId == BookId).Count();
        }
        public IEnumerable<BorrowReturnActionVM> GetUnavilableBooks()
        {
            return _mapping.iMapper.Map<IEnumerable<BorrowReturnActionVM>>
              (_bookservice.GetAllBooks().
              Where(b => b.CopiesNumber == GetBorrowedBooks().Where(book => book.BookId == b.id).Count()));
        }
        public IEnumerable<BorrowReturnActionVM> GetBooksExcedeedAllowedBorrowingPeriod()
        {
            return _mapping.iMapper.Map<IEnumerable<BorrowReturnActionVM>>
        (_uow.GetRepoInstance().GetAll().Where(b => b.BorrowDate > DateTime.MinValue
        & b.ReturnDate == DateTime.MinValue & (DateTime.Now.Date- b.BorrowDate.Date).Days > b.Book.BorrowType.AllowedBorrowPeriod));

        }
        public int GetCountofBooksExcedeedAllowedBorrowingPeriod()
        {
            return 
                    (_uow.GetRepoInstance().GetAll().Where(b => b.BorrowDate > DateTime.MinValue
                    & b.ReturnDate == DateTime.MinValue & (DateTime.Now.Date - b.BorrowDate.Date).Days > b.Book.BorrowType.AllowedBorrowPeriod)).Count();
        }

        public int GetCountofBorrowedBooksNotExcedingAllowedBorrowingPeriod()
        {
            return 
                    (_uow.GetRepoInstance().GetAll().Where(b => b.BorrowDate > DateTime.MinValue
                    & b.ReturnDate == DateTime.MinValue & (DateTime.Now.Date - b.BorrowDate.Date).Days <= b.Book.BorrowType.AllowedBorrowPeriod)).Count();
        }
       public int GetTotalCountofBooks()
        {
          return  _bookservice.GetAllBooks().Sum(i=>i.CopiesNumber);
        }
       public Tuple<int,int,int> BookSharePercentage()
        {
            int BooksExcedeedAllowedBorrowingPeriodPercentage = 0;
            int BooksNotExcedeedAllowedBorrowingPeriodPercentage = 0;
            int BooksAvailablePercentage = 0;
            int BooksExcedeedAllowedBorrowingPeriod = GetCountofBooksExcedeedAllowedBorrowingPeriod();
            int BooksTotal = GetTotalCountofBooks();
            int BooksNotExcedeedAllowedBorrowingPeriod = GetCountofBorrowedBooksNotExcedingAllowedBorrowingPeriod();
            if (BooksTotal != 0)
            {
                 BooksExcedeedAllowedBorrowingPeriodPercentage = BooksExcedeedAllowedBorrowingPeriod * 100 / BooksTotal;
                 BooksNotExcedeedAllowedBorrowingPeriodPercentage = BooksNotExcedeedAllowedBorrowingPeriod * 100 / BooksTotal;
                 BooksAvailablePercentage = 100 - (BooksExcedeedAllowedBorrowingPeriodPercentage + BooksNotExcedeedAllowedBorrowingPeriodPercentage);
            }
            

            return new Tuple<int, int, int>(BooksExcedeedAllowedBorrowingPeriodPercentage, BooksNotExcedeedAllowedBorrowingPeriodPercentage, BooksAvailablePercentage);
        }
    }
}
