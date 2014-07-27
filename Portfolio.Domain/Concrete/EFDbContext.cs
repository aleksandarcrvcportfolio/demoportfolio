using System.Data.Entity;
using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
    }
}
