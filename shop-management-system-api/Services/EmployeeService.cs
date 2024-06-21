using shop_management_system_api.Models;
using shop_management_system_api.Services.Interfaces;
using shop_management_system_api.Repositories;
using shop_management_system_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace shop_management_system_api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IManagerRepository _managerRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IManagerRepository managerRepository)
        {

            _employeeRepository = employeeRepository;
            _managerRepository = managerRepository;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {

          Employee newEmployee = await _employeeRepository.AddEmployee(employee);

            return newEmployee;

        }

        public async Task<List<Employee>> GetAll()
        {
            List<Employee> employees = await _employeeRepository.GetAll();

            return employees;
        }

        public async Task<List<EmployeeDTO>> EmployeesWithManagers()
        {
            List<Employee> employees = await _employeeRepository.GetAll();
           
            List<EmployeeDTO> employeesWithManagers = new List<EmployeeDTO>();

                foreach (Employee employee in  employees)
            {
                Manager manager = await  _managerRepository.GetManagerById(employee.ManagerId);

                EmployeeDTO employeeWithManager = new EmployeeDTO
                {
                    EmployeeNumber = employee.EmployeeNumber,
                    Title = employee.Title,
                    FullName = employee.FullName,
                    CurrentManager = manager.FullName,
                    DOB = employee.DOB,
                    Gender = employee.Gender,
                    Email = employee.Email,
                    IsActive = employee.IsActive,
                };

                employeesWithManagers.Add(employeeWithManager);
            }
            
                return employeesWithManagers;

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
