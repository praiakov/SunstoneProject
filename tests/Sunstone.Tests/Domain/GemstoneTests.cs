using Sunstone.Domain;

namespace Sunstone.Tests.Domain
{
    public class GemstoneTests
    {
        [Fact]
        public void Add_Gemstone_DoesNotThrow()
        {
            // Arrange & act
            var gemstone = new Gemstone(name: "Amethyst", color: Colors.Purple);

            // Assert
            Assert.NotNull(gemstone);
        }

        [Theory]
        [InlineData("Old Burma Ruby")]
        [InlineData("Axinite")]
        [InlineData("Black Opal")]
        public void Add_InvalidColor_ThrowsDomainException(string name)
            => Assert.Throws<DomainException>(() => new Gemstone(name: name, color: (Colors)18));

        [Theory]
        [InlineData("", Colors.Orange)]
        [InlineData(null, Colors.Colourless)]
        public void Add_GemstoneNameIsNullOrWhiteSpace_ThrowsDomainException(string name, Colors color)
            => Assert.Throws<DomainException>(() => new Gemstone(name: name, color: color));

    }
}
