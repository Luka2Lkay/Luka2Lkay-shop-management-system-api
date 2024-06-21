using Microsoft.EntityFrameworkCore;
using shop_management_system_api.Data;
using shop_management_system_api.Models;
using shop_management_system_api.Repositories.Interfaces;

namespace shop_management_system_api.Repositories
{
    public class ManagerRepository : IManagerRepository
    {

        private readonly MyShopContext _shopContext;

        public ManagerRepository(MyShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<Manager> AddManager(Manager manager)
        {

            _shopContext.Managers.Add(manager);
            await _shopContext.SaveChangesAsync();

            return manager;
        }

        public async Task<List<Manager>> GetAll()
        {
            List<Manager> managers = await _shopContext.Managers.ToListAsync();

            return managers;
        }

        public async Task<Manager> GetManagerById(int id)
        {
            Manager? manager = await _shopContext.Managers.FindAsync(id);

            return manager;
        }

        public async Task<Manager> RemoveManagerById(int id)
        {
            Manager? manager = await _shopContext.Managers.FindAsync(id);

            if (manager == null) {

                return null;
            }

            _shopContext.Managers.Remove(manager);
            _shopContext.SaveChanges();

            return manager;
        }

        public async Task UpdateManager(Manager manager)
        {
            Manager? selectedManager = await _shopContext.Managers.FindAsync(manager.Id);

            if (selectedManager != null) {
                selectedManager.EmployeeNumber = manager.EmployeeNumber;
                selectedManager.FullName = manager.FullName;
                selectedManager.DOB = manager.DOB;
                selectedManager.Gender = manager.Gender;
                selectedManager.Email = manager.Email;
                selectedManager.IsActive = manager.IsActive;

                await _shopContext.SaveChangesAsync();
            }
        }
    }
}
