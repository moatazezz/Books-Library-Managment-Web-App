using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Services;
using BLL.VM;
namespace LibraryApp.Controllers
{
    public class BorrowTypesController : Controller
    {
        private IBorrowTypeService _borrowTypeService;
        public BorrowTypesController(IBorrowTypeService borrowTypeService)
        {
            _borrowTypeService = borrowTypeService;
        }
        // GET: BorrowTypes
        public ActionResult Index()
        {
            var borrowtype =_borrowTypeService.GetAllBorrowTypes();
            return View(borrowtype);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BorrowTypeVM borrowtype)
        {
            //var id=  book.Category.id;
            if (ModelState.IsValid)
            {
                _borrowTypeService.AddBorrowType(borrowtype);
                return RedirectToAction("Index");
            }
            else
                return View(borrowtype);

        }
        public ActionResult Edit(int id)
        {
            var borrowtype = _borrowTypeService.GetBorrowTypesById(id);
            return View(borrowtype);
        }

        [HttpPost]
        public ActionResult Edit(BorrowTypeVM borrowtype)
        {
            if (ModelState.IsValid)
            {
                _borrowTypeService.EditBorrowType(borrowtype);
                return RedirectToAction("Index");
            }
            else
                return View(borrowtype);
        }
    }
}