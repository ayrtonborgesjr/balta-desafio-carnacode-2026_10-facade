using System;
using E_commerce.Consolle.DTO;
using E_commerce.Consolle.Subsystems;

namespace E_commerce.Consolle.Facade;

public class OrderFacade
{
    private readonly InventorySystem _inventory;
    private readonly PaymentGateway _payment;
    private readonly ShippingService _shipping;
    private readonly CouponSystem _coupon;
    private readonly NotificationService _notification;

    public OrderFacade()
    {
        _inventory = new InventorySystem();
        _payment = new PaymentGateway();
        _shipping = new ShippingService();
        _coupon = new CouponSystem();
        _notification = new NotificationService();
    }

    public bool FinalizeOrder(OrderDTO order)
    {
        try
        {
            Console.WriteLine("=== Processando Pedido via Facade ===\n");

            // 1️⃣ Verificar estoque
            if (!_inventory.CheckAvailability(order.ProductId, order.Quantity))
            {
                Console.WriteLine("❌ Produto indisponível");
                return false;
            }

            _inventory.ReserveProduct(order.ProductId, order.Quantity);

            // 2️⃣ Aplicar cupom
            decimal discount = 0;
            if (!string.IsNullOrEmpty(order.CouponCode) &&
                _coupon.ValidateCoupon(order.CouponCode))
            {
                discount = _coupon.GetDiscount(order.CouponCode);
            }

            // 3️⃣ Calcular total
            decimal subtotal = order.ProductPrice * order.Quantity;
            decimal discountAmount = subtotal * discount;
            decimal shippingCost = _shipping.CalculateShipping(order.ZipCode, order.Quantity * 0.5m);
            decimal total = subtotal - discountAmount + shippingCost;

            // 4️⃣ Processar pagamento
            string transactionId = _payment.InitializeTransaction(total);

            if (!_payment.ValidateCard(order.CreditCard, order.Cvv))
            {
                _inventory.ReleaseReservation(order.ProductId, order.Quantity);
                Console.WriteLine("❌ Cartão inválido");
                return false;
            }

            if (!_payment.ProcessPayment(transactionId, order.CreditCard))
            {
                _inventory.ReleaseReservation(order.ProductId, order.Quantity);
                Console.WriteLine("❌ Pagamento recusado");
                return false;
            }

            // 5️⃣ Criar envio
            string orderId = $"ORD{DateTime.Now.Ticks}";
            string labelId = _shipping.CreateShippingLabel(orderId, order.ShippingAddress);
            _shipping.SchedulePickup(labelId, DateTime.Now.AddDays(1));

            // 6️⃣ Marcar cupom
            if (!string.IsNullOrEmpty(order.CouponCode))
            {
                _coupon.MarkCouponAsUsed(order.CouponCode, order.CustomerEmail);
            }

            // 7️⃣ Notificações
            _notification.SendOrderConfirmation(order.CustomerEmail, orderId);
            _notification.SendPaymentReceipt(order.CustomerEmail, transactionId);
            _notification.SendShippingNotification(order.CustomerEmail, labelId);

            Console.WriteLine($"\n✅ Pedido {orderId} finalizado com sucesso!");
            Console.WriteLine($"   Total: R$ {total:N2}");

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro ao processar pedido: {ex.Message}");
            return false;
        }
    }
}