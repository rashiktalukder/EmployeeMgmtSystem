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

        public async Task<IActionResult> GetAllEmployees()
        {
            
            
            List<Employee> employeeList = await _context.Employees.ToListAsync();

            return Json(employeeList);
        }
    }
}
