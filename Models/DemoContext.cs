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
        public DbSet<QRCodes> QRCodes { get; set; }
        public DateTime ScannedAt { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//dont know if we need for unique constraint, dont delete yet
        {
            modelBuilder.Entity<AccountModel>()
                .HasIndex(u => u.acUsername)
                .IsUnique(); // Apply unique constraint

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        
          =>options.UseSqlite(@"Data Source=C:\Users\naido\Desktop\teli project\Demo.db");

    }
}
//Admin
//Username: Bull
//Password: Shit

//Parent
//Username: Niel
//Password: 0000

//Teacher
//Username: Veg
//Password: table
