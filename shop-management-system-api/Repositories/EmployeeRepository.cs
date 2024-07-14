using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_management_system_api.Data;
using shop_management_system_api.Models;
using shop_management_system_api.Repositories.Interfaces;

namespace shop_management_system_api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly MyShopContext _context;

        public EmployeeRepository(MyShopContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            Employee newEmployee = new Employee()
            {
                Id = employee.Id,
                ManagerId = employee.ManagerId,
                EmployeeNumber = employee.EmployeeNumber,
                FullName = employee.FullName,
                Title = employee.Title,
                DOB = employee.DOB,
                Gender = employee.Gender,
                Email = employee.Email,
                IsActive = employee.IsActive,
            };
        
            Manager? manager = await _context.Managers.FindAsync(newEmployee.ManagerId);

            if (manager == null)
            {

                throw new ArgumentException("Invalid managerId");

            }

            _context.Employees.Add(newEmployee);
            _context.SaveChanges();

            return employee;
        }

        public async Task<List<Employee>> GetAll()
        {
            List<Employee> employees = await _context.Employees.ToListAsync();

            return employees;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee? employee = await _context.Employees.FindAsync(id);

            return employee;
        }

        public async Task<Employee> RemoveEmployeeById(int id)
        {
            Employee? employee = await _context.Employees.FindAsync(id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return employee;
            }

            return null;
        }

        public async Task UpdateEmployee(Employee employee)

        {
            Employee? selectedEmployee = await _context.Employees.FindAsync(employee.Id);

            if (selectedEmployee != null)
            {

                selectedEmployee.EmployeeNumber = employee.EmployeeNumber;
                selectedEmployee.ManagerId = employee.ManagerId;
                selectedEmployee.FullName = employee.FullName;
                selectedEmployee.Title = employee.Title;
                selectedEmployee.DOB = employee.DOB;
                selectedEmployee.Gender = employee.Gender;
                selectedEmployee.Email = employee.Email;
                selectedEmployee.IsActive = employee.IsActive;

                await _context.SaveChangesAsync();
            }
        }
    }
}