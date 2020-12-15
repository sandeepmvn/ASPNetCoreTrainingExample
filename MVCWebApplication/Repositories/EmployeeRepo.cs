using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using MVCWebApplication.Models;

namespace MVCWebApplication.Repositories
{
    public interface IEmployeeRepo
    {
        /// <summary>
        /// get all employees
        /// </summary>
        /// <returns>List of TblEmployee</returns>
        Task<List<TblEmployee>> GetEmployees();

        Task<TblEmployee> GetEmployee(int id);

        Task<bool> IsEmployeeExists(int id);

        Task InsertEmployee(TblEmployee entity);

        Task UpdateEmployee(TblEmployee entity);

        Task RemoveEmployee(int id);
    }
    public class EmployeeRepo : IEmployeeRepo
    {
        private const string TBLEMPLOYEEKEY = "tblemloyee";

        #region PrivateMembers
        private readonly EmployeeDBContext _context;
        private readonly IMemoryCache _cache;
        private readonly ILogger<EmployeeRepo> _logger;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Employee DbContext reference</param>
        /// <param name="cache">Memory Cache</param>
        /// <param name="logger">Logger</param>
        public EmployeeRepo(EmployeeDBContext context,
            IMemoryCache cache,
            ILogger<EmployeeRepo> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        #endregion

        #region InterfaceImplementationMethods

        /// <summary>
        /// get all employees
        /// </summary>
        /// <returns>List of TblEmployee</returns>
        public async Task<List<TblEmployee>> GetEmployees()
        {
            List<TblEmployee> employees = null;
            if (!_cache.TryGetValue(TBLEMPLOYEEKEY, out employees))
            {
                _logger.LogInformation("no cache object is ..... trying to connect the employeedb");
                employees = await _context.Employees.ToListAsync();
                _cache.Set(TBLEMPLOYEEKEY, employees);
            }
            return employees;
        }

        public async Task<TblEmployee> GetEmployee(int id)
        {
            List<TblEmployee> employees = null;
            if (!_cache.TryGetValue(TBLEMPLOYEEKEY, out employees))
            {
             return await _context.Employees.FirstOrDefaultAsync(x => x.PKEmloyeeId == id);
            }
            
            return employees.FirstOrDefault(x => x.PKEmloyeeId == id);
        }

        public async Task InsertEmployee(TblEmployee entity)
        {
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
            _cache.Remove(TBLEMPLOYEEKEY);
        }

        public async Task UpdateEmployee(TblEmployee entity)
        {
            _context.Employees.Update(entity);
            await _context.SaveChangesAsync();
            _cache.Remove(TBLEMPLOYEEKEY);
        }

        public async Task RemoveEmployee(int id)
        {
            var entity = await GetEmployee(id);
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();
            _cache.Remove(TBLEMPLOYEEKEY);
        }

        public async Task<bool> IsEmployeeExists(int id)
        {
            List<TblEmployee> employees = null;
            if (!_cache.TryGetValue(TBLEMPLOYEEKEY, out employees))
            {
                return await _context.Employees.AnyAsync(x => x.PKEmloyeeId == id);
            }
            
            return employees.Any(x => x.PKEmloyeeId == id);
        }

        #endregion
    }
}
