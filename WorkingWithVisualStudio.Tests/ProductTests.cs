using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            // Arrange 
            var p = new Product { Name = "Macbook pro", Price = 1438 };

            // Act 
            p.Name = "Macbook pro mid 2014";

            // Assert 
            Assert.Equal("Macbook pro mid 2014", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            // Arrange
            var p = new Product { Name = "Mac pro", Price = 6000 };

            // Act
            p.Price = 6500;

            // Assert
            Assert.Equal(6500, p.Price);
        }
    }
}
