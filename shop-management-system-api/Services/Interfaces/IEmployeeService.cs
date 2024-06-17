using shop_management_system_api.Models;

namespace shop_management_system_api.Services.Interfaces
{
    public interface IEmployeeService
    {
        public void AddEmployee(Employee employee);

        public List<Employee> GetAll();
        public List<Employee> GetActiveEmployees(Employee employee);
        public void RemoveEmployeeById(int id);
        public Employee GetEmployeeById(int id);
        public void UpdateEmployee(Employee employee);
    }
}
