namespace EmployeeManagementAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public DateTime JoiningDate { get; set; }
        
        public String PhotoFileName { get; set; }
    }
}
