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

    }
}
