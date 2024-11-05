using Moq;
using InventoryService;
using ProductService.Services;
using System.Runtime.CompilerServices;

namespace ProductServiceTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            IMock<IProductService> mockRepository = new Mock<IProductService>();


            // Act


            // Assert
        }
    }
}