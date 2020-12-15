using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebApplication.Models;
using MVCWebApplication.Repositories;

namespace MVCWebApplication.Controllers
{
    public class TblEmployeesController : Controller
    {
        //private readonly EmployeeDBContext _context;
        private readonly IEmployeeRepo _employeeRepo;
        public TblEmployeesController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        // GET: TblEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _employeeRepo.GetEmployees());
        }

        // GET: TblEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmployee = await _employeeRepo.GetEmployee(id.Value);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            return View(tblEmployee);
        }

        // GET: TblEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PKEmloyeeId,EmployeeName,IsActive")] TblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(tblEmployee);
                //await _context.SaveChangesAsync();
                await _employeeRepo.InsertEmployee(tblEmployee);
                return RedirectToAction(nameof(Index));
            }
            return View(tblEmployee);
        }

        // GET: TblEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmployee = await _employeeRepo.GetEmployee(id.Value); //_context.Employees.FindAsync(id);
            if (tblEmployee == null)
            {
                return NotFound();
            }
            return View(tblEmployee);
        }

        // POST: TblEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PKEmloyeeId,EmployeeName,IsActive")] TblEmployee tblEmployee)
        {
            if (id != tblEmployee.PKEmloyeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(tblEmployee);
                    //await _context.SaveChangesAsync();
                    await _employeeRepo.UpdateEmployee(tblEmployee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _employeeRepo.IsEmployeeExists(tblEmployee.PKEmloyeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblEmployee);
        }

        // GET: TblEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmployee = await _employeeRepo.GetEmployee(id.Value); //_context.Employees
                                                                         //.FirstOrDefaultAsync(m => m.PKEmloyeeId == id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            return View(tblEmployee);
        }

        // POST: TblEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var tblEmployee = await _context.Employees.FindAsync(id);
            //_context.Employees.Remove(tblEmployee);
            //await _context.SaveChangesAsync();
            await _employeeRepo.RemoveEmployee(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool TblEmployeeExists(int id)
        //{
        //    return _context.Employees.Any(e => e.PKEmloyeeId == id);
        //}
    }
}
