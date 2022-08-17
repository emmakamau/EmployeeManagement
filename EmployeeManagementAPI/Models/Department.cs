namespace EmployeeManagementAPI.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        // Navigation
        public List<Employee> Employees { get; set; }
    }
}
