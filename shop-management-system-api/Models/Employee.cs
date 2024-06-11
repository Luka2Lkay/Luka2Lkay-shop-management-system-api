namespace shop_management_system_api.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public required string EmployeeNumber { get; set; }
        public required string FullName { get; set; }
        public required string Title { get; set; }
        public required string DOB { get; set; }
        public required string Gender { get; set; }
        public required string Email { get; set; }
        public Manager? Manager { get; set; }

        public Employee (Manager manager)
        {
            this.Manager = manager;
        }

        public bool IsActive { get; set; } = true;
    }
}
