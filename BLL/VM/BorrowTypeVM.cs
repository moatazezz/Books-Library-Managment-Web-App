using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace BLL.VM
{
    public class BorrowTypeVM
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Type must be specified")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Allowed Period must be specified")]
        public int AllowedBorrowPeriod { get; set; }
        public virtual ICollection<BooksVM> Books { get; set; }
        [Required(ErrorMessage = "Delay Penalty must be specified")]
        public decimal DelayPenalty { get; set; }
    }
}
