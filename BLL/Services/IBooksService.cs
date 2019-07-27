using BLL.VM;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
   public interface IBooksService
    {
        IEnumerable<BooksVM> GetAllBooks();
        BooksVM GetBookById(int id);
        void AddBook(BooksVM book);
        void EditBook(BooksVM book);

    }
}
