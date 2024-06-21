using shop_management_system_api.Models;

namespace shop_management_system_api.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<Employee> AddEmployee(Employee employee);

        public Task<List<Employee>> GetAll();

        public Task<List<EmployeeDTO>> EmployeesWithManagers();
        public Task<List<Employee>> GetActiveEmployees();
        public Task<Employee> RemoveEmployeeById(int id);
        public Task<Employee> GetEmployeeById(int id);
        public Task UpdateEmployee(Employee employee);
    }
}
