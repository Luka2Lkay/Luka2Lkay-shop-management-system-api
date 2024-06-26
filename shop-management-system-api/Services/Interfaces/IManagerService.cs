using shop_management_system_api.Models;

namespace shop_management_system_api.Services.Interfaces
{
    public interface IManagerService
    {
        public Task<Manager> AddManager(Manager manager);

        public Task<List<Manager>> ManagersWithEmployees();
        public Task<List<Manager>> GetAll();
        public Task<List<Manager>> GetActiveManagers();
        public Task<Manager> RemoveManagerById(int id);
        public Task<Manager> GetManagerById(int id);
        public Task UpdateManager(Manager manager);
        public Task<int> GetManagerIdByName(Manager manager);

    }
}
