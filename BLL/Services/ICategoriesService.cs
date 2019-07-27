using BLL.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
  public  interface ICategoriesService
    {
        IEnumerable<CategoriesVM> GetAllCategories();
        CategoriesVM GetCategoryByID(int id);
        void AddCategory(CategoriesVM Category);
        void EditCategory(CategoriesVM Category);
    }
}
