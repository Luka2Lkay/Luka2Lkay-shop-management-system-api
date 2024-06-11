using Microsoft.EntityFrameworkCore; 
using shop_management_system_api.Models;

namespace shop_management_system_api.Data
{
    public class ShopContext : DbContext
    {
       public ShopContext(DbContextOptions options) : base(options) { 

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}
