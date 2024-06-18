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

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
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