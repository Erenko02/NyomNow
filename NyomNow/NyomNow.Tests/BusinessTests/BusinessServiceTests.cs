namespace NyomNow.NyomNow.Tests.BusinessTests
{
    using Moq;
    using NyomNow.Api.Business;
    using NyomNow.Api.Models;
    using NyomNow.Api.Services;
    using Xunit;

    public class BusinessServiceTests
    {
        [Fact]
        public async Task GetTotalOrdersAsync_ReturnsCorrectCount()
        {
            // Arrange
            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(s => s.GetAllOrdersAsync())
                            .ReturnsAsync(new List<Order> { new Order(), new Order() });

            var businessService = new BusinessService(mockOrderService.Object);

            // Act
            var result = await businessService.GetTotalOrdersAsync();

            // Assert
            Assert.Equal(2, result);
        }
    }
}