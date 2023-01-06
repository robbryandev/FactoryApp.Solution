using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
    public class FactoryContext : DbContext
    {
        public DbSet<Example> Examples { get; set; }
        public FactoryContext(DbContextOptions options) : base(options) { }
    }
}