using shop_management_system_api.Models;
using shop_management_system_api.Repositories.Interfaces;
using shop_management_system_api.Services.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace shop_management_system_api.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
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
