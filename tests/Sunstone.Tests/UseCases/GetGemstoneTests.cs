using Moq;
using Sunstone.Application;
using Sunstone.Domain;

namespace Sunstone.Tests.UseCases
{
    public class GetGemstoneTests
    {
        [Fact]
        public async Task GetGemstoneUseCase_ReturnsList()
        {
            // Arrange
            var gemstones = GemstonesMock(); 
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(repo => repo.Get()).ReturnsAsync(gemstones);
            

            var getGemstoneUseCase = new GetGemstoneUseCase(repositoryMock.Object);

            // Act
            var result = await getGemstoneUseCase.GetGemstones();

            // Assert
            repositoryMock.Verify(repo => repo.Get());
            // Assert
            repositoryMock.Verify(repo => repo.Get(), Times.Once());
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Gemstone>>(result);
            Assert.Equal(gemstones.Count(), result.Count());

        }


        private static IEnumerable<Gemstone> GemstonesMock()
        {

            return new List<Gemstone>()
            {
               new Gemstone("TestGem", Colors.White),
               new Gemstone("TestGem", Colors.Red),
               new Gemstone("TestGem", Colors.Black),
            };
        }
    }
}
