using Microsoft.EntityFrameworkCore;
using Sunstone.Domain;

namespace Sunstone.Infra
{
    public class Repository : IRepository
    {
        private readonly SunstoneInMemoryContext _sunstoneInMemoryContext;

        public Repository(SunstoneInMemoryContext sunstoneInMemoryContext)
        {
            _sunstoneInMemoryContext = sunstoneInMemoryContext;
        }

        public Task Create(Gemstone gemstone)
        {
            _sunstoneInMemoryContext.Add(gemstone);
            _sunstoneInMemoryContext.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Gemstone>> Get() => await _sunstoneInMemoryContext.Gemstones.ToListAsync();
    }
}
