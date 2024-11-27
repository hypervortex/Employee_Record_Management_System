using Employee_Record_Management_System.Data;
using Employee_Record_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Record_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeesController(EmployeeDbContext context)
        {
            _context = context;
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeId }, employee);
        }

        // GET: api/Employees/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // PUT: api/Employees/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (id != employee.EmployeeId)
                return BadRequest("Employee ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee == null)
                return NotFound($"Employee with ID {id} not found");

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.MobileNumber = employee.MobileNumber;
            existingEmployee.AlternateNumber = employee.AlternateNumber;
            existingEmployee.BirthDate = employee.BirthDate;
            existingEmployee.AnniversaryDate = employee.AnniversaryDate;
            existingEmployee.Address = employee.Address;
            existingEmployee.City = employee.City;
            existingEmployee.Pincode = employee.Pincode;
            existingEmployee.BloodGroup = employee.BloodGroup;
            existingEmployee.EmergencyContactName = employee.EmergencyContactName;
            existingEmployee.EmergencyNumber = employee.EmergencyNumber;
            existingEmployee.DateOfJoining = employee.DateOfJoining;

            _context.Entry(existingEmployee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); 
        }
    }
}
