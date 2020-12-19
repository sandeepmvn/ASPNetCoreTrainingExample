using System;
using System.Collections.Generic;
using System.Text;
using EmployeeDeptWebApplication.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace EmployeeDeptWebApplication.Repositories
{
    public class DepartmentRepo:GenericRepository<Department>,IDepartmentRepo
    {
        public DepartmentRepo(EmpDeptWebAppDBContext context, ILogger<DepartmentRepo> logger,IMemoryCache cache) : base(context, logger, cache)
        {
        }
    }
}
