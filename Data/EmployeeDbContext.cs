using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class EmployeeDbContext : DbContext
    {
        protected readonly IConfiguration configuration;
        public EmployeeDbContext(IConfiguration configuration)
        {
            this.configuration=configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(configuration.GetConnectionString("cruddb"));
        }
        public DbSet<Employee> Employees { get; set; }
    }
}