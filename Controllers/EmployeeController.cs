using EmployeeAPI.Data;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext dbcontext ;
        public EmployeeController(EmployeeDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            return Ok(await dbcontext.Employees.ToListAsync());

        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployee addEmployee)
        {
            var employee = new Employee()
            {
                id = Guid.NewGuid(),
                Name = addEmployee.Name,
                Position = addEmployee.Position,
                Department = addEmployee.Position
            };
            await dbcontext.Employees.AddAsync(employee);
            await dbcontext.SaveChangesAsync();
            return Ok(employee);

        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id , UpdateEmployee updateEmployee)
        {
            var employee = await dbcontext.Employees.FindAsync(id);
            if(employee != null)
            {
                employee.Name = updateEmployee.Name;
                employee.Position = updateEmployee.Position;
                employee.Department = updateEmployee.Department;
                await dbcontext.Employees.AddAsync(employee);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployeeUsingId([FromRoute] Guid id)
        {
            var employee = await dbcontext.Employees.FindAsync(id);
            if(employee != null)
            {
                return Ok(employee);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await dbcontext.Employees.FindAsync(id);
            if(employee != null)
            {
                dbcontext.Employees.Remove(employee);
                await dbcontext.SaveChangesAsync();
                return Ok(employee);
            }
            return NotFound();
        }

    }
}