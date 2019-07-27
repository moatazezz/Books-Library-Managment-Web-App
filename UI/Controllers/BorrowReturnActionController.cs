using BLL.Services;
using BLL.VM;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace LibraryApp.Controllers
{
    public class BorrowReturnActionController : Controller
    {
        // GET: BorrowReturnAction
        private static IBorrowReturnActionService _borrowreturnactionservice;
        private static IService<Borrowers, BorrowersVM> _borrowersservice;

        private static IBooksService _booksservice;
        private static ICategoriesService _categoriesservice;
        private static IBorrowTypeService _borrowTypeService;
        public BorrowReturnActionController(IBooksService booksservice, ICategoriesService categoriesservice, IBorrowTypeService borrowTypeService, IBorrowReturnActionService borrowreturnactionservice, IService<Borrowers, BorrowersVM> borrowersservice)
        {
            _booksservice = booksservice;
            _categoriesservice = categoriesservice;
            _borrowTypeService = borrowTypeService;
            _borrowreturnactionservice = borrowreturnactionservice;
            _borrowersservice = borrowersservice;
        }
        public ActionResult Index()
        {
            var BorrowReturnActions = _borrowreturnactionservice.GetBorrowedBooks();
            return View(BorrowReturnActions);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BorrowReturnActionVM BorrowReturnAction)
        {
            if (ModelState.IsValid)
            {
                _borrowreturnactionservice.Add(BorrowReturnAction);
                return RedirectToAction("Index");
            }
            else
                return View(BorrowReturnAction);
        }
        public ActionResult Edit(int id)
        {
          var BorrowedBook=  _borrowreturnactionservice.GetById(id);
            return View(BorrowedBook);
        }
        [HttpPost]
        public ActionResult Edit(BorrowReturnActionVM BorrowReturnAction)
        {
            _borrowreturnactionservice.Update(BorrowReturnAction);
            return RedirectToAction("Index");
        }
        public static IEnumerable<BorrowersVM> GetBorrowers ()
        {
            return _borrowersservice.GetAll();
        }
        public static IEnumerable<BorrowReturnActionVM> GetBorrowReturnActions()
        {
            return _borrowreturnactionservice.GetAll();
        }
        public static IEnumerable<BooksVM> GetBooks()
        {
            return _booksservice.GetAllBooks();
        }
        public JsonResult CountBorrowedBooksExceededLimit()
        {
            return  Json   (new { count = _borrowreturnactionservice.GetCountofBooksExcedeedAllowedBorrowingPeriod() }, JsonRequestBehavior.AllowGet) ;
        }
        public ActionResult Search(string searchid = null)
        {
            if (searchid == "" | searchid == null)
            {
                return View(_borrowreturnactionservice.GetAvilableBooks());
            }
            else
            {
                return View(_borrowreturnactionservice.GetAvilableBooksById(Convert.ToInt32(searchid)));
            }
            
        }
        public JsonResult GetAvailableCopies(int BookId)
        {
            var no = _borrowreturnactionservice.GetNumberOfAvailableCopies(BookId);
            return Json(new { AvailableCopies = no }, JsonRequestBehavior.AllowGet);
        }
        public static IEnumerable<BooksVM> GetAvailableBooks()
        {
            return _borrowreturnactionservice.GetAvilableBooks();
        }
    }
}