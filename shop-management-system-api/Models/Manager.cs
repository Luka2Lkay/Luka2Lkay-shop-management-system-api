using System.ComponentModel.DataAnnotations;

namespace shop_management_system_api.Models
{
        public class Manager
    {
        public int Id { get; set; }
        public required string EmployeeNumber { get; set; }
        public required string FullName { get; set; }
        public required string DOB { get; set; }
        public required string Gender { get; set; }
        public required string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Employee> ManagedEmployees { get; set; } = new List<Employee>();
    }
}
