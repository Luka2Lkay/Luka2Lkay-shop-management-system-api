namespace shop_management_system_api.Models
{
    public class EmployeeDTO
    {
        public required string EmployeeNumber { get; set; }
        public required string Title { get; set; }
        public required string FullName { get; set; }
        public required string CurrentManager { get; set; }
        public required string DOB { get; set; }
        public required string Gender { get; set; }
        public required string Email { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
