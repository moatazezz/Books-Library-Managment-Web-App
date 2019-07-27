using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF
{
    public class Books
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Title must be specified")]
        public string title { get; set; }
        [Required(ErrorMessage = "Auther must be specified")]
        public string auther { get; set; }
        [Required(ErrorMessage = "Category must be specified")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Categories Category { get; set; }
        [Required(ErrorMessage = "Borrow Type must be specified")]
        [ForeignKey("BorrowType")]
        public int BorrowTypeId { get; set; }
        public virtual BorrowType BorrowType { get; set; }
        public virtual ICollection<BorrowReturnAction> BorrowReturnActions { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int CopiesNumber { get; set; }
    }
}
