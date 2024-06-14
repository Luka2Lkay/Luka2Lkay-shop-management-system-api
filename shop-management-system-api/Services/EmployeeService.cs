using shop_management_system_api.Models;
using shop_management_system_api.Services.Interfaces;
using shop_management_system_api.Repositories;

namespace shop_management_system_api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeService(EmployeeRepository employeeRepository) {
        
            _employeeRepository = employeeRepository;
        }
        public void AddEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
        }
    }
}
