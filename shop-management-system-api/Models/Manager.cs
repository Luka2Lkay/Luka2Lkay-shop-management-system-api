namespace shop_management_system_api.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public required string EmployeeNumber { get; set; }
        public required string FullName { get; set; }
        public required string DOB { get; set; }
        public required string Gender { get; set; }
        public required string Email { get; set; }
        public bool IsActive { get; set; } = true;

        public List<Employee> ManagedEmployees { get; set; }

        public Manager ()
        {
            ManagedEmployees = new List<Employee>();
        }

        public void AddEmployee (Employee employee)
        {
            ManagedEmployees.Add(employee);
        }
    }
}
