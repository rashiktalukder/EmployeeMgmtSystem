using EmployeeMgmtSystem.DataAccess;
using EmployeeMgmtSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMgmtSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateEmployee(Employee employeeObj)
        {
            try
            {
                await _context.Employees.AddAsync(employeeObj);
                await _context.SaveChangesAsync();

                return Json(new { Succeeded = true, Message = "Employee Created Successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { succeeded = false, message = $"An error occurred: {ex.Message}" });
            }

        }

        public async Task<IActionResult> UpdateEmployee(Employee employeeObj)
        {
            try
            {
                var existingEmp = await _context.Employees.FindAsync(employeeObj.Id);

                if(existingEmp==null)
                {
                    return Json(new { Succeeded = false, Message = "Employee Does not Exist!" });
                }

                existingEmp.Name = employeeObj.Name;
                existingEmp.Email = employeeObj.Email;
                existingEmp.Phone = employeeObj.Phone;
                existingEmp.Position = employeeObj.Position;
                existingEmp.JoinDate = employeeObj.JoinDate;
                existingEmp.Status = employeeObj.Status;

                _context.Employees.Update(existingEmp);
                await _context.SaveChangesAsync();

                return Json(new { Succeeded = true, Message = "Employee Updated Successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { succeeded = false, message = $"An error occurred: {ex.Message}" });
            }

        }

        public async Task<IActionResult> GetAllEmployees()
        {
            List<Employee> employeeList = await _context.Employees.Where(x=>x.IsDeleted == false).ToListAsync();

            return Json(employeeList);
        }

        public async Task<IActionResult> DeleteEmployee(int empId)
        {
            var existingEmp = await _context.Employees.FindAsync(empId);
            if (existingEmp == null)
            {
                return Json(new { Succeeded = false, Message = "Employee Does not Exist!" });
            }

            existingEmp.IsDeleted = true;
            _context.Employees.Update(existingEmp);
            await _context.SaveChangesAsync();
            return Json(new { Succeeded = true, Message = "Employee Deleted Successfully!" });
        }
    }
}
