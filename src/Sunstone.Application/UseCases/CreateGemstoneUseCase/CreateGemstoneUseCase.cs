using Sunstone.Domain;

namespace Sunstone.Application
{
    public class CreateGemstoneUseCase : ICreateGemstoneUseCase
    {
        private readonly IRepository _repository;

        public CreateGemstoneUseCase(IRepository repository) => _repository = repository;

        public async Task<Guid> CreateGemstone(CreateInputModel gemstone)
        {
            var gstone = new Gemstone(gemstone.Name, gemstone.Colors);

            await _repository.Create(gstone);

            return gstone.Id;

        }
    }
}
