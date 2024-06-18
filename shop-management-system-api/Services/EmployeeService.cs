using shop_management_system_api.Models;
using shop_management_system_api.Services.Interfaces;
using shop_management_system_api.Repositories;
using shop_management_system_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace shop_management_system_api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {

            _employeeRepository = employeeRepository;
        }

        public void AddEmployee(Employee employee)
        {

            _employeeRepository.AddEmployee(employee);

        }

        public async Task<List<Employee>> GetAll()
        {
            List<Employee> employees = await _employeeRepository.GetAll();

            return employees;
        }

        public async Task<List<Employee>> GetActiveEmployees()
        {
            List<Employee> employees = await _employeeRepository.GetAll();

            List<Employee> activeEmployees = employees.Where(x => x.IsActive == true).ToList();

            return activeEmployees;

        }
        public  Task<Employee> RemoveEmployeeById(int id)
        {
            return  _employeeRepository.RemoveEmployeeById(id);
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetEmployeeById(id);
        }

        public async Task UpdateEmployee(Employee employee)
        {
           await _employeeRepository.UpdateEmployee(employee);
        }

    }

}
