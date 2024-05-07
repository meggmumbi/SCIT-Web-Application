using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SCIT.Entities;

namespace SCIT.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Programmes> Programmes { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Department> Department { get; set; }

        public DbSet<ProgrammeApplications> ProgrammeApplications { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

    }
}
