using E_commerce.Consolle.Subsystems;

namespace E_commerce.Tests;

public class NotificationServiceTests
{
    [Fact]
    public void SendOrderConfirmation_ShouldNotThrowException()
    {
        // Arrange
        var notification = new NotificationService();

        // Act & Assert
        var exception = Record.Exception(() => 
            notification.SendOrderConfirmation("customer@email.com", "ORD123"));
        Assert.Null(exception);
    }

    [Fact]
    public void SendPaymentReceipt_ShouldNotThrowException()
    {
        // Arrange
        var notification = new NotificationService();

        // Act & Assert
        var exception = Record.Exception(() => 
            notification.SendPaymentReceipt("customer@email.com", "TXN123"));
        Assert.Null(exception);
    }

    [Fact]
    public void SendShippingNotification_ShouldNotThrowException()
    {
        // Arrange
        var notification = new NotificationService();

        // Act & Assert
        var exception = Record.Exception(() => 
            notification.SendShippingNotification("customer@email.com", "LBL123"));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("user@test.com", "ORD001")]
    [InlineData("customer@email.com", "ORD999")]
    [InlineData("test@example.com", "ORD12345")]
    public void SendOrderConfirmation_ShouldAcceptVariousInputs(string email, string orderId)
    {
        // Arrange
        var notification = new NotificationService();

        // Act & Assert
        var exception = Record.Exception(() => 
            notification.SendOrderConfirmation(email, orderId));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("user@test.com", "TXN001")]
    [InlineData("customer@email.com", "TXN999")]
    public void SendPaymentReceipt_ShouldAcceptVariousInputs(string email, string transactionId)
    {
        // Arrange
        var notification = new NotificationService();

        // Act & Assert
        var exception = Record.Exception(() => 
            notification.SendPaymentReceipt(email, transactionId));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("user@test.com", "LBL-001")]
    [InlineData("customer@email.com", "LBL-999")]
    public void SendShippingNotification_ShouldAcceptVariousInputs(string email, string trackingCode)
    {
        // Arrange
        var notification = new NotificationService();

        // Act & Assert
        var exception = Record.Exception(() => 
            notification.SendShippingNotification(email, trackingCode));
        Assert.Null(exception);
    }
}

