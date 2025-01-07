namespace EmployeeMgmtSystem.Models
{
    public class PerformanceReview
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ReviewDate { get; set; }
        public double ReviewScore { get; set; } = 0.0;
        public string? ReviewNotes { get; set; } = "";
    }
}
