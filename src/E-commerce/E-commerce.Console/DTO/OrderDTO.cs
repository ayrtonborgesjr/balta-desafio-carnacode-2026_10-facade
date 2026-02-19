namespace E_commerce.Consolle.DTO;

public class OrderDTO(
    string productId,
    int quantity,
    string customerEmail,
    string creditCard,
    string cvv,
    string shippingAddress,
    string zipCode,
    string couponCode,
    decimal productPrice)
{
    public string ProductId { get; } = productId;
    public int Quantity { get; } = quantity;
    public string CustomerEmail { get; } = customerEmail;
    public string CreditCard { get; } = creditCard;
    public string Cvv { get; } = cvv;
    public string ShippingAddress { get; } = shippingAddress;
    public string ZipCode { get; } = zipCode;
    public string CouponCode { get; } = couponCode;
    public decimal ProductPrice { get; } = productPrice;
}