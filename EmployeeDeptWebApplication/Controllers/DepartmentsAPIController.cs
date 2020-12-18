using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeDeptWebApplication.Models;
using EmployeeDeptWebApplication.Repositories;

namespace EmployeeDeptWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsAPIController : ControllerBase
    {
        private readonly IDepartmentRepo _deptRepo;

        public DepartmentsAPIController(IDepartmentRepo deptRepo)
        {
            _deptRepo = deptRepo;
        }

        // GET: api/DepartmentsAPI
        [ProducesResponseType(typeof(IEnumerable<Department>),200)]
        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(_deptRepo.GetAll());
        }

        // GET: api/DepartmentsAPI/5
        [ProducesResponseType(typeof(Department),200)]
        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            var department = _deptRepo.GetBy(x=>x.Id==id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // PUT: api/DepartmentsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [ProducesResponseType(204)]
        [HttpPut("{id}")]
        public  IActionResult PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            try
            {
                _deptRepo.Update(department);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DepartmentsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostDepartment(Department department)
        {
            _deptRepo.Add(department);
            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/DepartmentsAPI/5
        [ProducesResponseType(204)]
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            _deptRepo.Delete(id);
            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return _deptRepo.GetAllBy(x => x.Id == id)?.Count() > 0;
        }
    }
}
