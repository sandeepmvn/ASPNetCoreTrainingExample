using System;
using System.Collections.Generic;
using System.Text;
using EmployeeDeptWebApplication.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeDeptWebApplication.Repositories
{
    public class EmployeeRepo : GenericRepository<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(EmpDeptWebAppDBContext context, ILogger<EmployeeRepo> logger) : base(context, logger)
        {
        }

    }
}
