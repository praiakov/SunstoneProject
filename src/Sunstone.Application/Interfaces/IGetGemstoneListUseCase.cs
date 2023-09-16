using Sunstone.Domain;

namespace Sunstone.Application
{
    public interface IGetGemstoneListUseCase
    {
        Task<IEnumerable<Gemstone>> GetGemstones();
    }
}
