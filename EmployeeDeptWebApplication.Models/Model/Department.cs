using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeDeptWebApplication.Models
{
    public class Department : PrimaryKey<int>
    {
        #region Constants
        public const int NameLength = 100;
        #endregion

        #region Properties
        /// <summary>
        /// Department Name
        /// </summary>
        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        //public bool IsActive { get; set; }
        #endregion

        #region Associations
        /// <summary>
        /// Employee Navigation Property
        /// </summary>
        public List<Employee> Employees { get; set; }

        #endregion
    }
}
