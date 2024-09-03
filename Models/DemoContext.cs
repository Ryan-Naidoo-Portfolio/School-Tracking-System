using Microsoft.EntityFrameworkCore; 
namespace test_Data.Models
{
    public class DemoContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        
          =>options.UseSqlite(@"Data Source=C:\Users\User\source\repos\Teli_Boys\Demo.db");


    }
}
