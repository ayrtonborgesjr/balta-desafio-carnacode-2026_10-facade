using E_commerce.Consolle.Subsystems;

namespace E_commerce.Tests;

public class ShippingServiceTests
{
    [Fact]
    public void CalculateShipping_ShouldReturnCorrectAmount()
    {
        // Arrange
        var shipping = new ShippingService();

        // Act
        var cost = shipping.CalculateShipping("12345-678", 1.0m);

        // Assert
        Assert.Equal(17.0m, cost); // 15 + (1 * 2)
    }

    [Theory]
    [InlineData(0.5, 16.0)] // 15 + (0.5 * 2)
    [InlineData(2.0, 19.0)] // 15 + (2.0 * 2)
    [InlineData(5.0, 25.0)] // 15 + (5.0 * 2)
    public void CalculateShipping_ShouldCalculateBasedOnWeight(decimal weight, decimal expectedCost)
    {
        // Arrange
        var shipping = new ShippingService();

        // Act
        var cost = shipping.CalculateShipping("12345-678", weight);

        // Assert
        Assert.Equal(expectedCost, cost);
    }

    [Fact]
    public void CalculateShipping_ShouldHaveMinimumCost()
    {
        // Arrange
        var shipping = new ShippingService();

        // Act
        var cost = shipping.CalculateShipping("12345-678", 0m);

        // Assert
        Assert.Equal(15.0m, cost); // Custo mínimo
    }

    [Fact]
    public void CreateShippingLabel_ShouldReturnLabelWithOrderId()
    {
        // Arrange
        var shipping = new ShippingService();
        var orderId = "ORD123456";

        // Act
        var label = shipping.CreateShippingLabel(orderId, "Rua Exemplo, 123");

        // Assert
        Assert.NotNull(label);
        Assert.Equal($"LBL-{orderId}", label);
    }

    [Fact]
    public void CreateShippingLabel_ShouldReturnDifferentLabels_ForDifferentOrders()
    {
        // Arrange
        var shipping = new ShippingService();

        // Act
        var label1 = shipping.CreateShippingLabel("ORD001", "Endereço 1");
        var label2 = shipping.CreateShippingLabel("ORD002", "Endereço 2");

        // Assert
        Assert.NotEqual(label1, label2);
    }

    [Fact]
    public void SchedulePickup_ShouldNotThrowException()
    {
        // Arrange
        var shipping = new ShippingService();
        var pickupDate = DateTime.Now.AddDays(1);

        // Act & Assert
        var exception = Record.Exception(() => 
            shipping.SchedulePickup("LBL-ORD123", pickupDate));
        Assert.Null(exception);
    }

    [Fact]
    public void SchedulePickup_ShouldAcceptFutureDate()
    {
        // Arrange
        var shipping = new ShippingService();
        var futureDate = DateTime.Now.AddDays(7);

        // Act & Assert
        var exception = Record.Exception(() => 
            shipping.SchedulePickup("LBL-ORD123", futureDate));
        Assert.Null(exception);
    }
}

