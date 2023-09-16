namespace Sunstone.Application
{
    public interface ICreateGemstoneUseCase
    {
        Task<Guid> CreateGemstone(CreateInputModel gemstone);

    }
}
