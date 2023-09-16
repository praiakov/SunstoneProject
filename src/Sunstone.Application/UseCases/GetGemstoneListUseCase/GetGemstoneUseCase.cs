using Sunstone.Domain;

namespace Sunstone.Application
{
    public class GetGemstoneUseCase : IGetGemstoneListUseCase
    {
        private readonly IRepository _repository;

        public GetGemstoneUseCase(IRepository repository) => _repository = repository;

        public Task<IEnumerable<Gemstone>> GetGemstones() => _repository.Get();

    }
}
