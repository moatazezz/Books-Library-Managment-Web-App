using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
   public class Borrowers
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public virtual ICollection<BorrowReturnAction> BorrowReturnActions { get; set; }
    }
}
