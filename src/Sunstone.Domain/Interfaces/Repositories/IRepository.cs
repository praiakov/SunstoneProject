namespace Sunstone.Domain
{
    public interface IRepository
    {
        Task Create(Gemstone gemstone);
        Task<IEnumerable<Gemstone>> Get();
    }
}
