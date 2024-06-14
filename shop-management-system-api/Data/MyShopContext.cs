using Microsoft.EntityFrameworkCore; 
using shop_management_system_api.Models;

namespace shop_management_system_api.Data
{
    public class MyShopContext : DbContext
    {
       public MyShopContext(DbContextOptions options) : base(options) { 

        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
      
    }
}
