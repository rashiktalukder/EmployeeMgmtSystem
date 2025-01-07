using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMgmtSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Budget { get; set; }

        [ForeignKey("Employee")]
        public int ManagerId { get; set; } 
        public Employee Manager { get; set; }

        public List<Employee>? Employees { get; set; } //one to many relationship
    }
}
