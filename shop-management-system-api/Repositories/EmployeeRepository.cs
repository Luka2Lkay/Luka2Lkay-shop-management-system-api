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

        public  List<Employee> GetAll()
        {
            return  _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }

        public void RemoveEmployeeById(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            _context.Update(employee);
            _context.SaveChanges();
        }
    }
}