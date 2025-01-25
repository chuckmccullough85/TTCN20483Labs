using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Payroll;

public class PayrollDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Contractor> Contractors { get; set; }
    public DbSet<Intern> Interns { get; set; }
    public DbSet<Company> Companies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=payroll.db");
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().Ignore(e=>e.LocalTax);
        modelBuilder.Entity<Employee>().ToTable("Employees");
        modelBuilder.Entity<Contractor>().ToTable("Contractors");
    }
}