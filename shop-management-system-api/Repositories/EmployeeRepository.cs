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
        }
    }
}
