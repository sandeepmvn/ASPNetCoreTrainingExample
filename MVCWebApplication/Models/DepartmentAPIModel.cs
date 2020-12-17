using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApplication.Models
{
    public class DepartmentAPIModel
    {
        public int PkdepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
    }
}
