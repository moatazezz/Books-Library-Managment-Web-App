using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Services;
using BLL.VM;
namespace LibraryApp.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        // GET: Categories
        public ActionResult Index()
        {
            var categories =_categoriesService.GetAllCategories();
            return View(categories);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoriesVM category)
        {
            //var id=  categories.Category.id;
            if (ModelState.IsValid)
            {
                _categoriesService.AddCategory(category);
                return RedirectToAction("Index");
            }
            else
                return View(category);

        }
        public ActionResult Edit(int id)
        {
            var categories = _categoriesService.GetCategoryByID(id);
            return View(categories);
        }
        
        [HttpPost]
        public ActionResult Edit(CategoriesVM category)
        {
            if (ModelState.IsValid)
            {
                _categoriesService.EditCategory(category);
                return RedirectToAction("Index");
            }
            else
                return View(category);
        }
    }
}