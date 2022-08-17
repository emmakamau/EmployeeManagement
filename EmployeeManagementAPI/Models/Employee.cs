namespace EmployeeManagementAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime JoiningDate { get; set; }
        
        public String PhotoFileName { get; set; }

        // Relationships
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
