using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetPostgresCrud.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [NotMapped]
        public string DisplayID { get; set; }

        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        
        [DisplayName("Emp. Code")]
        public string EmpCode { get; set; }
        
        public string Position { get; set; }
        
        [DisplayName("Office Location")]
        public string OfficeLocation { get; set; }
    }
}
