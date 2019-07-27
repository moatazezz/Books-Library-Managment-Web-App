using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryApp.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        private static IBorrowReturnActionService _borrowreturnactionservice;
        public DashBoardController(IBorrowReturnActionService borrowreturnactionservice)
        {
            _borrowreturnactionservice = borrowreturnactionservice;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetStatisitcs()
        {
         var data=   _borrowreturnactionservice.BookSharePercentage();
            return Json(new { Available = data.Item3, BorrowedNotExceeding = data.Item2, BorrowedExceeding = data.Item1 }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBorrowedBooksNotification()
        {
            var books=_borrowreturnactionservice.GetBooksExcedeedAllowedBorrowingPeriod();
            return View(books);
        }
    }
}