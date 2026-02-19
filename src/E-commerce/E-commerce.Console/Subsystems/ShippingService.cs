namespace E_commerce.Consolle.Subsystems;

public class ShippingService
{
    public decimal CalculateShipping(string zipCode, decimal weight)
    {
        Console.WriteLine($"[Envio] Calculando frete para {zipCode}");

        // Simulação simples
        return 15m + (weight * 2);
    }

    public string CreateShippingLabel(string orderId, string address)
    {
        Console.WriteLine($"[Envio] Criando etiqueta para {orderId}");

        return $"LBL-{orderId}";
    }

    public void SchedulePickup(string labelId, DateTime date)
    {
        Console.WriteLine($"[Envio] Coleta agendada para {date:dd/MM/yyyy}");
    }
}