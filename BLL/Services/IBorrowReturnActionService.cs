using BLL.VM;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
 public interface IBorrowReturnActionService :IService<BorrowReturnAction, BorrowReturnActionVM>
    {
        IEnumerable<BorrowReturnActionVM> GetBorrowedBooks();
        IEnumerable<BooksVM> GetAvilableBooks();
        IEnumerable<BooksVM> GetAvilableBooksById(int BookId);
        IEnumerable<BorrowReturnActionVM> GetUnavilableBooks();
        int GetNumberOfAvailableCopies(int BookId);
        IEnumerable<BorrowReturnActionVM> GetBooksExcedeedAllowedBorrowingPeriod();
        int GetCountofBooksExcedeedAllowedBorrowingPeriod();
        int GetCountofBorrowedBooksNotExcedingAllowedBorrowingPeriod();
        int GetTotalCountofBooks();
        Tuple<int, int, int> BookSharePercentage();
    }
}
