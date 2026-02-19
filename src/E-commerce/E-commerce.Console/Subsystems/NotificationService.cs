namespace E_commerce.Consolle.Subsystems;

public class NotificationService
{
    public void SendOrderConfirmation(string email, string orderId)
    {
        Console.WriteLine($"[Notificação] Confirmação enviada para {email}");
    }

    public void SendPaymentReceipt(string email, string transactionId)
    {
        Console.WriteLine($"[Notificação] Recibo {transactionId} enviado");
    }

    public void SendShippingNotification(string email, string trackingCode)
    {
        Console.WriteLine($"[Notificação] Código de rastreio enviado");
    }
}