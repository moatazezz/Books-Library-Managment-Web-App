using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class Categories
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<Books> Books {get; set;}
    }
}
