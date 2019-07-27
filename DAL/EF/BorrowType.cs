using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
  public  class BorrowType
    {
        public int id { get; set; }
        public string Type { get; set; }
        public int AllowedBorrowPeriod { get; set; }
        public virtual ICollection<Books> Books { get; set; }
        public decimal DelayPenalty { get; set; }
    }
}
