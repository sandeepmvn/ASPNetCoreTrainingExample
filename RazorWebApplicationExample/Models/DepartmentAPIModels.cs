using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApplicationExample.Models
{
    public class DepartmentAPIModels
    {
        [Required]
        public int PkdepartmentId { get; set; }
        [Required]
        [StringLength(10)]
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
    }
}
