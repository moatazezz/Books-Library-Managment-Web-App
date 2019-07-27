using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace BLL.VM
{
   public class BorrowReturnActionVM
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Books must be specified")]
        public int BookId { get; set; }
        public virtual BooksVM Book { get; set; }
        [Required(ErrorMessage = "Brower must be specified")]
        public int BorrowerId { get; set; }
        public virtual BorrowersVM Borrowers { get; set; }
        [Required(ErrorMessage = "Borrow Date must be specified")]
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
