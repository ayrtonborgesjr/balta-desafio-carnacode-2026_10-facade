using E_commerce.Consolle.Subsystems;

namespace E_commerce.Tests;

public class CouponSystemTests
{
    [Fact]
    public void ValidateCoupon_ShouldReturnTrue_WhenCouponExists()
    {
        // Arrange
        var couponSystem = new CouponSystem();

        // Act
        var result = couponSystem.ValidateCoupon("PROMO10");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateCoupon_ShouldReturnFalse_WhenCouponDoesNotExist()
    {
        // Arrange
        var couponSystem = new CouponSystem();

        // Act
        var result = couponSystem.ValidateCoupon("INVALID");

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("PROMO10")]
    [InlineData("SAVE20")]
    public void ValidateCoupon_ShouldReturnTrue_ForValidCoupons(string couponCode)
    {
        // Arrange
        var couponSystem = new CouponSystem();

        // Act
        var result = couponSystem.ValidateCoupon(couponCode);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetDiscount_ShouldReturn10Percent_ForPROMO10()
    {
        // Arrange
        var couponSystem = new CouponSystem();

        // Act
        var discount = couponSystem.GetDiscount("PROMO10");

        // Assert
        Assert.Equal(0.10m, discount);
    }

    [Fact]
    public void GetDiscount_ShouldReturn20Percent_ForSAVE20()
    {
        // Arrange
        var couponSystem = new CouponSystem();

        // Act
        var discount = couponSystem.GetDiscount("SAVE20");

        // Assert
        Assert.Equal(0.20m, discount);
    }

    [Fact]
    public void GetDiscount_ShouldReturnZero_WhenCouponDoesNotExist()
    {
        // Arrange
        var couponSystem = new CouponSystem();

        // Act
        var discount = couponSystem.GetDiscount("INVALID");

        // Assert
        Assert.Equal(0m, discount);
    }

    [Theory]
    [InlineData("PROMO10", 0.10)]
    [InlineData("SAVE20", 0.20)]
    [InlineData("INVALID", 0.00)]
    public void GetDiscount_ShouldReturnCorrectValue_ForDifferentCoupons(string code, decimal expected)
    {
        // Arrange
        var couponSystem = new CouponSystem();

        // Act
        var discount = couponSystem.GetDiscount(code);

        // Assert
        Assert.Equal(expected, discount);
    }

    [Fact]
    public void MarkCouponAsUsed_ShouldNotThrowException()
    {
        // Arrange
        var couponSystem = new CouponSystem();

        // Act & Assert
        var exception = Record.Exception(() => 
            couponSystem.MarkCouponAsUsed("PROMO10", "customer@email.com"));
        Assert.Null(exception);
    }

    [Fact]
    public void MarkCouponAsUsed_ShouldAcceptValidParameters()
    {
        // Arrange
        var couponSystem = new CouponSystem();

        // Act & Assert
        var exception = Record.Exception(() => 
            couponSystem.MarkCouponAsUsed("SAVE20", "user123@test.com"));
        Assert.Null(exception);
    }
}

