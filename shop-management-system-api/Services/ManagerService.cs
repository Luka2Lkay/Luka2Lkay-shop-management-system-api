using shop_management_system_api.Models;
using shop_management_system_api.Repositories.Interfaces;
using shop_management_system_api.Services.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace shop_management_system_api.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ManagerService(IManagerRepository managerRepository, IEmployeeRepository employeeRepository)
        {
            _managerRepository = managerRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<Manager> AddManager(Manager manager)
        {
            return await _managerRepository.AddManager(manager);
        }

        public async Task<List<Manager>> GetActiveManagers()
        {
            List<Manager> managers = await _managerRepository.GetAll();
            List<Manager> activeManagers = managers.Where(manager => manager.IsActive).ToList();

            return activeManagers;
        }

        public async Task<List<Manager>> ManagersWithEmployees() {

            List<Manager> managers = await _managerRepository.GetAll();
            List<Manager> managersWith = new List<Manager>();
            List<Employee> employees = await _employeeRepository.GetAll();
            List<Employee> newEmployees = new List<Employee>();

            foreach (Manager manager in managers)
            {
                Employee employee = employees.FirstOrDefault(x => x.ManagerId == manager.Id); // fix here

                if (employee == null) {

                    throw new Exception("No matching employee");
                }

                Employee newEmployee = new Employee()
                {
                    EmployeeNumber = employee.EmployeeNumber,
                    FullName = employee.FullName,
                    Title = employee.Title,
                    DOB = employee.DOB,
                    Gender = employee.Gender,
                    Email = employee.Email,
                    IsActive = employee.IsActive,
                };

                newEmployees.Add(newEmployee);

                Manager newManager = new Manager()
                {
                    EmployeeNumber = manager.EmployeeNumber,
                    FullName = manager.FullName,
                    DOB = manager.DOB,
                    Gender = manager.Gender,
                    Email = manager.Email,
                    IsActive = manager.IsActive,
                    ManagedEmployees = newEmployees
                };

                managersWith.Add(newManager);
            }

            return managersWith;

        }

        public  async Task<List<Manager>> GetAll()
        {
            List<Manager> managers = await _managerRepository.GetAll();

            return managers;
        }

        public async Task<Manager> GetManagerById(int id)
        {
            Manager manager = await _managerRepository.GetManagerById(id);

            return manager;
        }

        public async Task<Manager> RemoveManagerById(int id)
        {
            return await _managerRepository.RemoveManagerById(id);
        }

        public async Task UpdateManager(Manager manager)
        {
            await _managerRepository.UpdateManager(manager);
        }
    }
}
