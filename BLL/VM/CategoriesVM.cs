using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace BLL.VM
{
   public class CategoriesVM
    {
            public int id { get; set; }
            [Required(ErrorMessage = "Category must be specified")]
            public string name { get; set; }
            public virtual ICollection<Books> Books { get; set; }
        
    }
}
