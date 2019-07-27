using BLL.VM;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
   public interface IBorrowTypeService
    {
         IEnumerable<BorrowTypeVM> GetAllBorrowTypes();
        BorrowTypeVM GetBorrowTypesById(int id);
        void AddBorrowType(BorrowTypeVM BorrowType);
        void EditBorrowType(BorrowTypeVM BorrowType);
    }
}
