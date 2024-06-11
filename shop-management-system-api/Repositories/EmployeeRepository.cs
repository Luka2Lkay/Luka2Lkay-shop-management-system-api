using Microsoft.EntityFrameworkCore;
using shop_management_system_api.Data;
using shop_management_system_api.Models;
using shop_management_system_api.Repositories.Interfaces;

namespace shop_management_system_api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
       
        private readonly ShopContext _shopContext;

        public EmployeeRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public void AddEmployee(Employee employee)
        {
            _shopContext.Employees.Add(employee);
        }
    }
}
