using E_commerce.Consolle.DTO;

namespace E_commerce.Tests;

public class OrderDTOTests
{
    [Fact]
    public void Constructor_ShouldSetAllProperties()
    {
        // Arrange & Act
        var order = new OrderDTO(
            productId: "PROD001",
            quantity: 2,
            customerEmail: "test@email.com",
            creditCard: "1234567890123456",
            cvv: "123",
            shippingAddress: "Rua Exemplo, 123",
            zipCode: "12345-678",
            couponCode: "PROMO10",
            productPrice: 100.00m
        );

        // Assert
        Assert.Equal("PROD001", order.ProductId);
        Assert.Equal(2, order.Quantity);
        Assert.Equal("test@email.com", order.CustomerEmail);
        Assert.Equal("1234567890123456", order.CreditCard);
        Assert.Equal("123", order.Cvv);
        Assert.Equal("Rua Exemplo, 123", order.ShippingAddress);
        Assert.Equal("12345-678", order.ZipCode);
        Assert.Equal("PROMO10", order.CouponCode);
        Assert.Equal(100.00m, order.ProductPrice);
    }

    [Fact]
    public void Constructor_ShouldAllowEmptyCouponCode()
    {
        // Arrange & Act
        var order = new OrderDTO(
            productId: "PROD001",
            quantity: 1,
            customerEmail: "test@email.com",
            creditCard: "1234567890123456",
            cvv: "123",
            shippingAddress: "Rua Exemplo, 123",
            zipCode: "12345-678",
            couponCode: "",
            productPrice: 50.00m
        );

        // Assert
        Assert.Equal("", order.CouponCode);
    }


    [Theory]
    [InlineData(1, 50.00)]
    [InlineData(5, 100.00)]
    [InlineData(10, 25.50)]
    public void Constructor_ShouldAcceptDifferentQuantitiesAndPrices(int quantity, decimal price)
    {
        // Arrange & Act
        var order = new OrderDTO(
            "PROD001", quantity, "test@email.com", "1234567890123456",
            "123", "Address", "12345-678", "", price
        );

        // Assert
        Assert.Equal(quantity, order.Quantity);
        Assert.Equal(price, order.ProductPrice);
    }
}

