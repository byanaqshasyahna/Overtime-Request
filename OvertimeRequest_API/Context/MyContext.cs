using Microsoft.EntityFrameworkCore;
using OvertimeRequest_API.Models;

namespace OvertimeRequest_API.Context
{
    public class MyContext : DbContext 
    {
        public MyContext(DbContextOptions<MyContext> option) : base(option)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAccount> RoleAccounts { get; set; }
        public DbSet <Overtime> Overtimes { get; set; }
        public DbSet <EmployeeOvertime > EmployeeOvertimes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(a => a.Account)
                .WithOne(b => b.Employee)
                .HasForeignKey<Account>(k => k.NIP);

            modelBuilder.Entity<RoleAccount>()
                .HasKey(ra => new { ra.RoleId, ra.NIP });

            modelBuilder.Entity<RoleAccount>()
                .HasOne(ra => ra.Role)
                .WithMany(r => r.RoleAccounts)
                .HasForeignKey(ra => ra.RoleId);

            modelBuilder.Entity<RoleAccount>()
                .HasOne(ra => ra.Account)
                .WithMany(a => a.RoleAccounts)
                .HasForeignKey(ra => ra.NIP);

            modelBuilder.Entity<EmployeeOvertime>()
                .HasKey(eo => new { eo.NIP, eo.OvertimeId });
            modelBuilder.Entity<EmployeeOvertime>()
                .HasOne(o => o.Overtime)
                .WithMany(eo => eo.EmployeeOvertime)
                .HasForeignKey(o => o.OvertimeId);
            modelBuilder.Entity<EmployeeOvertime>()
                .HasOne(e => e.Employee)
                .WithMany(eo => eo.EmployeeOvertime)
                .HasForeignKey(e => e.NIP);

        }
    }      
}
