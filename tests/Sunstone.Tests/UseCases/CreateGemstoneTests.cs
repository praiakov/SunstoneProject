using Moq;
using Sunstone.Application;
using Sunstone.Domain;

namespace Sunstone.Tests.UseCases
{
    public class CreateGemstoneTests
    {
        [Fact]
        public async Task CreateGemstone_ValidInput_CreatesGemstoneAndReturnsId()
        {
            // Arrange
            var gemstone = new Gemstone("TestGem", Colors.Red);
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(repo => repo.Create(It.IsAny<Gemstone>())).Returns(Task.CompletedTask);

            var createGemstoneUseCase = new CreateGemstoneUseCase(repositoryMock.Object);

            // Act
            var result = await createGemstoneUseCase.CreateGemstone(new CreateInputModel
            {
                Name = gemstone.Name,
                Colors = gemstone.Color
            });

            // Assert
            repositoryMock.Verify(repo => repo.Create(It.Is<Gemstone>(g => g.Name == gemstone.Name && g.Color.Equals(gemstone.Color))), Times.Once());
            Assert.Equal(Guid.Empty, result);
        }
    }
}
