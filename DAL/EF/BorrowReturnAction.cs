using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF
{
 public  class BorrowReturnAction
    {
        public int id { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Books Book { get; set; }

        [ForeignKey("Borrowers")]
        public int BorrowerId { get; set; }
        public virtual  Borrowers Borrowers { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
