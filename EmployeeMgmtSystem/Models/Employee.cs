using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMgmtSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public DateTime JoinDate { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId {  get; set; }
        public Department Department { get; set; } 

        public List<PerformanceReview>? PerformanceReviews { get; set; } //One to many relationship
    }
}
