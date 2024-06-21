using Microsoft.EntityFrameworkCore;
using shop_management_system_api.Models;

namespace shop_management_system_api.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<Employee> AddEmployee(Employee employee);

        public Task<List<Employee>> GetAll();

        public Task<Employee> GetEmployeeById(int id);

        public Task<Employee> RemoveEmployeeById(int id);

        public Task UpdateEmployee(Employee employee);
    }
}