using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;

namespace SMS.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }

    }
}
