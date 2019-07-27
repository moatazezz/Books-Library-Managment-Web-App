using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApp.Models
{
    public class BorrowReturnAction
    {
        public int id { get; set; }
        public int BookId { get; set; }
        public virtual Books Book { get; set; }
        public int BorrowerId { get; set; }
        public virtual Borrowers Borrowers { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}