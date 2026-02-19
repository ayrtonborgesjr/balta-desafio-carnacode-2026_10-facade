using E_commerce.Consolle.Subsystems;

namespace E_commerce.Tests;

public class PaymentGatewayTests
{
    [Fact]
    public void InitializeTransaction_ShouldReturnTransactionId()
    {
        // Arrange
        var payment = new PaymentGateway();

        // Act
        var transactionId = payment.InitializeTransaction(100.00m);

        // Assert
        Assert.NotNull(transactionId);
        Assert.NotEmpty(transactionId);
        Assert.StartsWith("TXN", transactionId);
    }

    [Fact]
    public void InitializeTransaction_ShouldReturnUniqueIds()
    {
        // Arrange
        var payment = new PaymentGateway();

        // Act
        var id1 = payment.InitializeTransaction(100.00m);
        var id2 = payment.InitializeTransaction(100.00m);

        // Assert
        Assert.NotEqual(id1, id2);
    }

    [Fact]
    public void ValidateCard_ShouldReturnTrue_WhenCardIsValid()
    {
        // Arrange
        var payment = new PaymentGateway();

        // Act
        var result = payment.ValidateCard("1234567890123456", "123");

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("123", "123")] // Cartão muito curto
    [InlineData("12345678901234567", "123")] // Cartão muito longo
    [InlineData("", "123")] // Cartão vazio
    [InlineData(null, "123")] // Cartão nulo
    public void ValidateCard_ShouldReturnFalse_WhenCardNumberIsInvalid(string cardNumber, string cvv)
    {
        // Arrange
        var payment = new PaymentGateway();

        // Act
        var result = payment.ValidateCard(cardNumber, cvv);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("1234567890123456", "")]
    [InlineData("1234567890123456", null)]
    [InlineData("1234567890123456", "   ")]
    public void ValidateCard_ShouldReturnFalse_WhenCvvIsInvalid(string cardNumber, string cvv)
    {
        // Arrange
        var payment = new PaymentGateway();

        // Act
        var result = payment.ValidateCard(cardNumber, cvv);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ProcessPayment_ShouldReturnTrue_WhenPaymentIsProcessed()
    {
        // Arrange
        var payment = new PaymentGateway();
        var transactionId = payment.InitializeTransaction(100.00m);

        // Act
        var result = payment.ProcessPayment(transactionId, "1234567890123456");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void RollbackTransaction_ShouldNotThrowException()
    {
        // Arrange
        var payment = new PaymentGateway();
        var transactionId = payment.InitializeTransaction(100.00m);

        // Act & Assert
        var exception = Record.Exception(() => payment.RollbackTransaction(transactionId));
        Assert.Null(exception);
    }
}

