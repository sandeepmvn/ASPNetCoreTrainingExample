using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeDeptWebApplication.Models
{
    public class PrimaryKey<T>
    {
        [Key]
        public T Id { get; set; }
    }


    //public class CreationLogger
    //{
    //    public DateTime CreationDate { get; set; }
    //}


    //public class ModificationLogger
    //{
    //    public Nullable<DateTime> ModifiedDate { get; set; }
    //}
}
