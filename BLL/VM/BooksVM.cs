using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.VM
{
   public class BooksVM
    {
        
            public int id { get; set; }
        [Required(ErrorMessage = "Title must be specified")]
        public string title { get; set; }
        [Required(ErrorMessage = "Auther must be specified")]
        public string auther { get; set; }
        [Required(ErrorMessage = "Category must be specified")]
        public int CategoryId { get; set; }
        public virtual CategoriesVM Category { get; set; }
        [Required(ErrorMessage = "Borrow Type must be specified")]
        public int BorrowTypeId { get; set; }
        public virtual BorrowTypeVM BorrowType { get; set; }
        [Required(ErrorMessage = "Copies Number must be specified")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int CopiesNumber { get; set; }
    }
}
