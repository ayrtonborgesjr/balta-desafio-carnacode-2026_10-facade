namespace E_commerce.Consolle.Subsystems;

public class CouponSystem
{
    private readonly Dictionary<string, decimal> _coupons = new()
    {
        ["PROMO10"] = 0.10m,
        ["SAVE20"] = 0.20m
    };

    public bool ValidateCoupon(string code)
    {
        Console.WriteLine($"[Cupom] Validando {code}");
        return _coupons.ContainsKey(code);
    }

    public decimal GetDiscount(string code)
    {
        return _coupons.TryGetValue(code, out var discount)
            ? discount
            : 0m;
    }

    public void MarkCouponAsUsed(string code, string customerId)
    {
        Console.WriteLine($"[Cupom] Cupom {code} usado por {customerId}");
    }
}