using Microsoft.EntityFrameworkCore; 
namespace test_Data.Models
{
    public class DemoContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ParentModel> Parents { get; set; }
        public DbSet<ChildModel> Child { get; set; }
        public DbSet<AttendanceModel> Attendance { get; set; }
        public DbSet<TeacherModel> Teacher { get; set; }
        public DbSet<AccountModel> Account { get; set; }
        public DbSet<AdminModel> Admin { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        
          =>options.UseSqlite(@"Data Source=C:\Users\HP\source\repos\Demo.db");


    }
}
