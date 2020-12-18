using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeDeptWebApplication.Models
{
    public class Employee:PrimaryKey<int>
    {
        #region Constants
        public const int NameLength = 100;
        #endregion

        #region Properties
        [Required]
        [StringLength(NameLength)]
        public string EmployeeName { get; set; }
        public bool IsActive { get; set; }
        #endregion

        #region Associations
        public int FKDepartmentId { get; set; }
        public Department Department { get; set; }
        #endregion

    }




}
