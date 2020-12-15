using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApplication.Models
{
    public class TblEmployee
    {
        [Key]
        public int PKEmloyeeId { get; set; }
        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        public bool IsActive { get; set; }
    }
}
