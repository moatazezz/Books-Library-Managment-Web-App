using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApp.Models
{
    public class Books
    {
        public int id { get; set; }
        public string title { get; set; }
        public string auther { get; set; }
        public int BorrowTypeId { get; set; }
        public virtual BorrowType BorrowType { get; set; }
    }
}