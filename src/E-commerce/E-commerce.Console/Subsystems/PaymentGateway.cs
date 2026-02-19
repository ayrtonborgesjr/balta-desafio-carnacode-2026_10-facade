namespace E_commerce.Consolle.Subsystems;

public class PaymentGateway
{
    public string InitializeTransaction(decimal amount)
    {
        Console.WriteLine($"[Pagamento] Inicializando transação de R$ {amount:N2}");
        return $"TXN{Guid.NewGuid():N}".Substring(0, 12);
    }

    public bool ValidateCard(string cardNumber, string cvv)
    {
        Console.WriteLine($"[Pagamento] Validando cartão");

        return cardNumber?.Length == 16 &&
               !string.IsNullOrWhiteSpace(cvv);
    }

    public bool ProcessPayment(string transactionId, string cardNumber)
    {
        Console.WriteLine($"[Pagamento] Processando {transactionId}");

        // Simulação
        return true;
    }

    public void RollbackTransaction(string transactionId)
    {
        Console.WriteLine($"[Pagamento] Revertendo {transactionId}");
    }
}