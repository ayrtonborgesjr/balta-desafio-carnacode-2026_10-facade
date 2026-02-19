using E_commerce.Consolle.Subsystems;

namespace E_commerce.Tests;

public class InventorySystemTests
{
    [Fact]
    public void CheckAvailability_ShouldReturnTrue_WhenProductIsAvailable()
    {
        // Arrange
        var inventory = new InventorySystem();

        // Act
        var result = inventory.CheckAvailability("PROD001", 5);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CheckAvailability_ShouldReturnFalse_WhenProductIsOutOfStock()
    {
        // Arrange
        var inventory = new InventorySystem();

        // Act
        var result = inventory.CheckAvailability("PROD003", 1);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CheckAvailability_ShouldReturnFalse_WhenQuantityExceedsStock()
    {
        // Arrange
        var inventory = new InventorySystem();

        // Act
        var result = inventory.CheckAvailability("PROD001", 20);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CheckAvailability_ShouldReturnFalse_WhenProductDoesNotExist()
    {
        // Arrange
        var inventory = new InventorySystem();

        // Act
        var result = inventory.CheckAvailability("PROD999", 1);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ReserveProduct_ShouldDecreaseStock_WhenProductExists()
    {
        // Arrange
        var inventory = new InventorySystem();
        var initialAvailability = inventory.CheckAvailability("PROD001", 10);

        // Act
        inventory.ReserveProduct("PROD001", 3);
        var afterReservation = inventory.CheckAvailability("PROD001", 10);

        // Assert
        Assert.True(initialAvailability);
        Assert.False(afterReservation);
        Assert.True(inventory.CheckAvailability("PROD001", 7));
    }

    [Fact]
    public void ReleaseReservation_ShouldIncreaseStock_WhenProductExists()
    {
        // Arrange
        var inventory = new InventorySystem();
        inventory.ReserveProduct("PROD001", 5);

        // Act
        inventory.ReleaseReservation("PROD001", 5);
        var result = inventory.CheckAvailability("PROD001", 10);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("PROD001", 1)]
    [InlineData("PROD001", 10)]
    [InlineData("PROD002", 5)]
    public void CheckAvailability_ShouldReturnTrue_ForValidQuantities(string productId, int quantity)
    {
        // Arrange
        var inventory = new InventorySystem();

        // Act
        var result = inventory.CheckAvailability(productId, quantity);

        // Assert
        Assert.True(result);
    }
}

