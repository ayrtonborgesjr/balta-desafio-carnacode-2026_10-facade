using E_commerce.Consolle.DTO;
using E_commerce.Consolle.Facade;

Console.WriteLine("=== Sistema de E-commerce ===\n");

var facade = new OrderFacade();

// Cenário 1: Pedido com cupom de desconto
Console.WriteLine("📦 CENÁRIO 1: Pedido com cupom de desconto\n");
var order1 = new OrderDTO(
    productId: "PROD001",
    quantity: 2,
    customerEmail: "cliente@email.com",
    creditCard: "1234567890123456",
    cvv: "123",
    shippingAddress: "Rua Exemplo, 123",
    zipCode: "12345-678",
    couponCode: "PROMO10",
    productPrice: 100.00m
);
facade.FinalizeOrder(order1);

Console.WriteLine("\n" + new string('=', 60) + "\n");

// Cenário 2: Pedido sem cupom de desconto
Console.WriteLine("📦 CENÁRIO 2: Pedido sem cupom de desconto\n");
var order2 = new OrderDTO(
    productId: "PROD002",
    quantity: 1,
    customerEmail: "maria.silva@email.com",
    creditCard: "9876543210987654",
    cvv: "456",
    shippingAddress: "Av. Principal, 456",
    zipCode: "54321-987",
    couponCode: "",
    productPrice: 250.00m
);
facade.FinalizeOrder(order2);

Console.WriteLine("\n" + new string('=', 60) + "\n");

// Cenário 3: Pedido com quantidade maior
Console.WriteLine("📦 CENÁRIO 3: Pedido com múltiplos itens\n");
var order3 = new OrderDTO(
    productId: "PROD003",
    quantity: 5,
    customerEmail: "joao.santos@email.com",
    creditCard: "1111222233334444",
    cvv: "789",
    shippingAddress: "Rua das Flores, 789",
    zipCode: "98765-432",
    couponCode: "PROMO10",
    productPrice: 50.00m
);
facade.FinalizeOrder(order3);

Console.WriteLine("\n" + new string('=', 60) + "\n");

// Cenário 4: Pedido de alto valor
Console.WriteLine("📦 CENÁRIO 4: Pedido de alto valor\n");
var order4 = new OrderDTO(
    productId: "PROD004",
    quantity: 1,
    customerEmail: "ana.costa@email.com",
    creditCard: "5555666677778888",
    cvv: "321",
    shippingAddress: "Alameda dos Anjos, 1000",
    zipCode: "11111-222",
    couponCode: "PROMO10",
    productPrice: 1500.00m
);
facade.FinalizeOrder(order4);

Console.WriteLine("\n" + new string('=', 60) + "\n");

// Cenário 5: Pedido com produto indisponível (simulação)
Console.WriteLine("📦 CENÁRIO 5: Tentativa de pedido adicional\n");
var order5 = new OrderDTO(
    productId: "PROD005",
    quantity: 3,
    customerEmail: "pedro.oliveira@email.com",
    creditCard: "9999888877776666",
    cvv: "654",
    shippingAddress: "Travessa do Comércio, 55",
    zipCode: "33333-444",
    couponCode: "",
    productPrice: 75.00m
);
facade.FinalizeOrder(order5);

Console.WriteLine("\n=== Processamento Concluído ===");
