using BLL.Mapping;
using BLL.VM;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CategoriesService : ICategoriesService
    {
        private IUnitOfWork<Categories> _uow;
        private IMapping _mapping;
        public CategoriesService(IUnitOfWork<Categories> UOW, IMapping mapping)
        {
            _uow = UOW;
            _mapping = mapping;
        }
        public IEnumerable<CategoriesVM> GetAllCategories()
        {
            return _mapping.iMapper.Map<IEnumerable<Categories>, IEnumerable<CategoriesVM>>(_uow.GetRepoInstance().GetAll());
        }
       public CategoriesVM GetCategoryByID(int id)
        {
            return _mapping.iMapper.Map<CategoriesVM>(_uow.GetRepoInstance().GetById(id));
        }
        public  void AddCategory(CategoriesVM Category)
        {
            _uow.GetRepoInstance().Insert(_mapping.iMapper.Map<Categories>( Category));
            _uow.SaveChanges();
        }
        public void EditCategory(CategoriesVM Category)
        {
            _uow.GetRepoInstance().Update(_mapping.iMapper.Map<Categories>(Category));
            _uow.SaveChanges();
        }
    }
}
