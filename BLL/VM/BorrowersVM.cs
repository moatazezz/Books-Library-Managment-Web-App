using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace BLL.VM
{
        public class BorrowersVM
        {
            public int id { get; set; }
             [Required(ErrorMessage = "Name must be specified")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Phone must be specified")]
            public string Phone { get; set; }
           [Required(ErrorMessage = "Address must be specified")]
           public string Address { get; set; }
        }
 
}
