using BLL.Services;
using BLL.VM;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {


    

        private  static IBooksService _booksservice;
        private  static ICategoriesService _categoriesservice;
        private static IBorrowTypeService _borrowTypeService;
        public  BooksController(IBooksService booksservice, ICategoriesService categoriesservice,IBorrowTypeService borrowTypeService)
        {
            _booksservice = booksservice;
            _categoriesservice = categoriesservice;
            _borrowTypeService = borrowTypeService;
        }
       
        public ActionResult Index()
        {
           var books= _booksservice.GetAllBooks();
            return View(books);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BooksVM book)
        {
            //var id=  book.Category.id;
            if (ModelState.IsValid)
            {
                _booksservice.AddBook(book);
                return RedirectToAction("Index");
            }
            else
                return View(book);
            
        }
        public  static IEnumerable<CategoriesVM> GetCategories()
        {
            return  _categoriesservice.GetAllCategories();
        }
        public static IEnumerable<BorrowTypeVM> GetBorrowTypes()
        {
            return _borrowTypeService.GetAllBorrowTypes();
        }
        public ActionResult Edit(int id)
        {
            var book = _booksservice.GetBookById(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(BooksVM book)
        {
            if (ModelState.IsValid)
            {
                _booksservice.EditBook(book);
                return RedirectToAction("Index");
            }
            else
                return View(book);
        }
    }
}