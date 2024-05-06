using Microsoft.EntityFrameworkCore;
using SCIT.Entities;

namespace SCIT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Programmes> Programmes { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Department> Department { get; set; }

        public DbSet<ProgrammeApplications> ProgrammeApplications { get; set; }

    }
}
