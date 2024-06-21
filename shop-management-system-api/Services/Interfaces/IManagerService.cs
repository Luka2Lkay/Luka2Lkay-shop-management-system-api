using shop_management_system_api.Models;

namespace shop_management_system_api.Services.Interfaces
{
    public interface IManagerService
    {
        public Task<Manager> AddManager(Manager manager);

        public Task<ManagerDTO> GetSelectedManagerInfo(int id);
        public Task<List<Manager>> GetAll();
        public Task<List<Manager>> GetActiveManagers();
        public Task<Manager> RemoveManagerById(int id);
        public Task<Manager> GetManagerById(int id);
        public Task UpdateManager(Manager manager);
    }
}
