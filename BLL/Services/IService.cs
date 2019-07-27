using BLL.VM;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
   public interface IService<T,TVM> 
    {
         
        IEnumerable<TVM> GetAll();
        void Add(TVM TVM);
        void Update(TVM TVM);
        TVM GetById(int id);
    }
}
