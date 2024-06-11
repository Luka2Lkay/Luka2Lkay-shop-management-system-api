using Microsoft.EntityFrameworkCore;
using shop_management_system_api.Models;

namespace shop_management_system_api.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
      public void AddEmployee(Employee employee);
    }
}
