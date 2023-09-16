using Microsoft.EntityFrameworkCore;
using Sunstone.Domain;

namespace Sunstone.Infra
{
    public class SunstoneInMemoryContext : DbContext
    {
        public SunstoneInMemoryContext(DbContextOptions<SunstoneInMemoryContext> options)
          : base(options)
        { }

        public DbSet<Gemstone> Gemstones { get; set; }
    }
}
