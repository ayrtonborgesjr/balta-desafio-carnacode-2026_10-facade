using E_commerce.Consolle.DTO;
using E_commerce.Consolle.Facade;

namespace E_commerce.Tests;

public class OrderFacadeTests
{
    [Fact]
    public void FinalizeOrder_ShouldReturnTrue_WhenOrderIsSuccessful()
    {
        // Arrange
        var facade = new OrderFacade();
        var order = new OrderDTO(
            productId: "PROD001",
            quantity: 2,
            customerEmail: "customer@email.com",
            creditCard: "1234567890123456",
            cvv: "123",
            shippingAddress: "Rua Exemplo, 123",
            zipCode: "12345-678",
            couponCode: "PROMO10",
            productPrice: 100.00m
        );

        // Act
        var result = facade.FinalizeOrder(order);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void FinalizeOrder_ShouldReturnTrue_WhenOrderWithoutCoupon()
    {
        // Arrange
        var facade = new OrderFacade();
        var order = new OrderDTO(
            productId: "PROD001",
            quantity: 1,
            customerEmail: "customer@email.com",
            creditCard: "1234567890123456",
            cvv: "123",
            shippingAddress: "Rua Exemplo, 123",
            zipCode: "12345-678",
            couponCode: "",
            productPrice: 100.00m
        );

        // Act
        var result = facade.FinalizeOrder(order);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void FinalizeOrder_ShouldReturnFalse_WhenProductOutOfStock()
    {
        // Arrange
        var facade = new OrderFacade();
        var order = new OrderDTO(
            productId: "PROD003", // Produto sem estoque
            quantity: 1,
            customerEmail: "customer@email.com",
            creditCard: "1234567890123456",
            cvv: "123",
            shippingAddress: "Rua Exemplo, 123",
            zipCode: "12345-678",
            couponCode: "",
            productPrice: 100.00m
        );

        // Act
        var result = facade.FinalizeOrder(order);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void FinalizeOrder_ShouldReturnFalse_WhenCardIsInvalid()
    {
        // Arrange
        var facade = new OrderFacade();
        var order = new OrderDTO(
            productId: "PROD001",
            quantity: 1,
            customerEmail: "customer@email.com",
            creditCard: "123", // Cartão inválido
            cvv: "123",
            shippingAddress: "Rua Exemplo, 123",
            zipCode: "12345-678",
            couponCode: "",
            productPrice: 100.00m
        );

        // Act
        var result = facade.FinalizeOrder(order);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void FinalizeOrder_ShouldReturnFalse_WhenCvvIsEmpty()
    {
        // Arrange
        var facade = new OrderFacade();
        var order = new OrderDTO(
            productId: "PROD001",
            quantity: 1,
            customerEmail: "customer@email.com",
            creditCard: "1234567890123456",
            cvv: "", // CVV vazio
            shippingAddress: "Rua Exemplo, 123",
            zipCode: "12345-678",
            couponCode: "",
            productPrice: 100.00m
        );

        // Act
        var result = facade.FinalizeOrder(order);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void FinalizeOrder_ShouldReturnTrue_WithValidCoupon()
    {
        // Arrange
        var facade = new OrderFacade();
        var order = new OrderDTO(
            productId: "PROD002",
            quantity: 1,
            customerEmail: "customer@email.com",
            creditCard: "1234567890123456",
            cvv: "456",
            shippingAddress: "Av. Principal, 456",
            zipCode: "54321-987",
            couponCode: "SAVE20",
            productPrice: 250.00m
        );

        // Act
        var result = facade.FinalizeOrder(order);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void FinalizeOrder_ShouldReturnTrue_WithInvalidCoupon()
    {
        // Arrange
        var facade = new OrderFacade();
        var order = new OrderDTO(
            productId: "PROD001",
            quantity: 1,
            customerEmail: "customer@email.com",
            creditCard: "1234567890123456",
            cvv: "123",
            shippingAddress: "Rua Exemplo, 123",
            zipCode: "12345-678",
            couponCode: "INVALID_COUPON", // Cupom inválido - não deve impedir o pedido
            productPrice: 100.00m
        );

        // Act
        var result = facade.FinalizeOrder(order);

        // Assert
        Assert.True(result); // O pedido deve ser processado mesmo com cupom inválido
    }

    [Fact]
    public void FinalizeOrder_ShouldReturnFalse_WhenQuantityExceedsStock()
    {
        // Arrange
        var facade = new OrderFacade();
        var order = new OrderDTO(
            productId: "PROD001",
            quantity: 100, // Quantidade maior que o estoque
            customerEmail: "customer@email.com",
            creditCard: "1234567890123456",
            cvv: "123",
            shippingAddress: "Rua Exemplo, 123",
            zipCode: "12345-678",
            couponCode: "",
            productPrice: 100.00m
        );

        // Act
        var result = facade.FinalizeOrder(order);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("PROD001", 1, "PROMO10")]
    [InlineData("PROD001", 2, "SAVE20")]
    [InlineData("PROD002", 1, "")]
    public void FinalizeOrder_ShouldProcessDifferentScenarios(string productId, int quantity, string couponCode)
    {
        // Arrange
        var facade = new OrderFacade();
        var order = new OrderDTO(
            productId: productId,
            quantity: quantity,
            customerEmail: "customer@email.com",
            creditCard: "1234567890123456",
            cvv: "123",
            shippingAddress: "Rua Exemplo, 123",
            zipCode: "12345-678",
            couponCode: couponCode,
            productPrice: 100.00m
        );

        // Act
        var result = facade.FinalizeOrder(order);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void FinalizeOrder_ShouldHandleMultipleOrders()
    {
        // Arrange
        var facade = new OrderFacade();
        var order1 = new OrderDTO(
            "PROD001", 1, "customer1@email.com", "1234567890123456",
            "123", "Address 1", "12345-678", "PROMO10", 100.00m
        );
        var order2 = new OrderDTO(
            "PROD002", 1, "customer2@email.com", "9876543210987654",
            "456", "Address 2", "54321-987", "", 200.00m
        );

        // Act
        var result1 = facade.FinalizeOrder(order1);
        var result2 = facade.FinalizeOrder(order2);

        // Assert
        Assert.True(result1);
        Assert.True(result2);
    }
}

