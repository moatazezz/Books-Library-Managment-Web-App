using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.EF;
using BLL.VM;
using BLL.Services;
namespace LibraryApp.Controllers
{
    public class BorrowersController : Controller
    {

        private static IService<Borrowers, BorrowersVM> _borrowersservice;
        public BorrowersController(IService<Borrowers, BorrowersVM> borrowersservice)
        {
            _borrowersservice = borrowersservice;
        }
        // GET: Borrowers
        public ActionResult Index()
        {
            var Borrowers =_borrowersservice.GetAll();
            return View(Borrowers);
        }

        public ActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BorrowersVM borrower)
        {
            if (ModelState.IsValid)
            {
                _borrowersservice.Add(borrower);
                return RedirectToAction("Index");
            }
            else
                return View(borrower);

        }
        public ActionResult Edit(int id)
        {
            var borrower =_borrowersservice.GetById(id);
            return View(borrower);
        }
      [HttpPost]
        public ActionResult Edit(BorrowersVM borrower)
        {
            if (ModelState.IsValid)
            {
                _borrowersservice.Update(borrower);
                return RedirectToAction("Index");
            }
            else
                return View(borrower);

        }
    }
}