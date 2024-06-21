using shop_management_system_api.Models;

namespace shop_management_system_api.Repositories.Interfaces
{
    public interface IManagerRepository
    {
        public Task<Manager> AddManager(Manager manager);

        public Task<List<Manager>> GetAll();

        public Task<Manager> GetManagerById(int id);

        public Task<Manager> RemoveManagerById(int id);

        public Task UpdateManager(Manager manager);
    }
}
