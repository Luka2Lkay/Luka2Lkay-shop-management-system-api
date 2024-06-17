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

        public  List<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public List<Employee> GetActiveEmployees(Employee employee)
        {
            return  _employeeRepository.GetAll().Where(x => x.IsActive == true).ToList();
        }
        public void RemoveEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
        }
        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }

    }

}
