using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace SampleRestfulAPI
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }
        public DbSet<Employee> Employee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EEHC0AO\\MSSQLSERVER01;Initial Catalog=Test;" +
                "Integrated Security=SSPI;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }

}
