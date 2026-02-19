# E-commerce.Tests

Este projeto contém os testes unitários para o sistema de E-commerce utilizando o padrão Facade.

## 📊 Cobertura de Testes

O projeto possui **69 testes unitários** cobrindo todos os componentes do sistema:

### ✅ Subsistemas Testados

#### 1. **InventorySystem** (Sistema de Estoque)
- ✓ Verificação de disponibilidade de produtos
- ✓ Reserva de produtos
- ✓ Liberação de reservas
- ✓ Tratamento de produtos inexistentes
- ✓ Validação de quantidades

**Total: 7 testes**

#### 2. **PaymentGateway** (Gateway de Pagamento)
- ✓ Inicialização de transações
- ✓ Geração de IDs únicos
- ✓ Validação de cartão de crédito
- ✓ Validação de CVV
- ✓ Processamento de pagamentos
- ✓ Rollback de transações

**Total: 9 testes**

#### 3. **ShippingService** (Serviço de Envio)
- ✓ Cálculo de frete baseado em peso
- ✓ Custo mínimo de frete
- ✓ Criação de etiquetas de envio
- ✓ Agendamento de coleta

**Total: 7 testes**

#### 4. **CouponSystem** (Sistema de Cupons)
- ✓ Validação de cupons existentes
- ✓ Validação de cupons inválidos
- ✓ Obtenção de descontos (10% e 20%)
- ✓ Marcação de cupons como usados

**Total: 9 testes**

#### 5. **NotificationService** (Serviço de Notificações)
- ✓ Envio de confirmação de pedido
- ✓ Envio de recibo de pagamento
- ✓ Envio de notificação de envio
- ✓ Processamento com diferentes parâmetros

**Total: 6 testes**

#### 6. **OrderDTO** (Data Transfer Object)
- ✓ Construção com todos os parâmetros
- ✓ Validação de propriedades read-only
- ✓ Cupons opcionais
- ✓ Diferentes quantidades e preços

**Total: 4 testes**

#### 7. **OrderFacade** (Facade Principal)
- ✓ Finalização bem-sucedida de pedidos
- ✓ Processamento com cupons válidos
- ✓ Processamento sem cupons
- ✓ Falha por produto indisponível
- ✓ Falha por cartão inválido
- ✓ Falha por CVV vazio
- ✓ Falha por quantidade excedente
- ✓ Tratamento de cupons inválidos
- ✓ Processamento de múltiplos pedidos

**Total: 11 testes**

## 🚀 Como Executar os Testes

### Executar todos os testes
```bash
dotnet test
```

### Executar com verbosidade detalhada
```bash
dotnet test --verbosity normal
```

### Executar com cobertura de código
```bash
dotnet test /p:CollectCoverage=true
```

### Executar testes de uma classe específica
```bash
dotnet test --filter "FullyQualifiedName~OrderFacadeTests"
```

## 📦 Dependências

- **xUnit** 2.9.2 - Framework de testes
- **xunit.runner.visualstudio** 2.8.2 - Visual Studio Test Runner
- **Microsoft.NET.Test.Sdk** 17.12.0 - SDK de testes
- **coverlet.collector** 6.0.2 - Cobertura de código

## 🎯 Padrões de Teste

Os testes seguem o padrão **AAA (Arrange-Act-Assert)**:

```csharp
[Fact]
public void MetodoTeste_DeveRetornarResultadoEsperado_QuandoCondicao()
{
    // Arrange - Preparar os dados e objetos
    var objeto = new MinhaClasse();

    // Act - Executar a ação
    var result = objeto.MetodoTestado();

    // Assert - Verificar o resultado
    Assert.True(result);
}
```

## 📈 Resultados

```
Resumo do teste:
- Total: 69 testes
- Bem-sucedidos: 69
- Falhados: 0
- Ignorados: 0
- Duração: ~4.1s
```

## 🔍 Cenários de Teste Cobertos

### Cenários de Sucesso
- ✅ Pedido completo com cupom válido
- ✅ Pedido sem cupom
- ✅ Pedido com diferentes quantidades
- ✅ Múltiplos pedidos sequenciais
- ✅ Cálculo correto de descontos e frete

### Cenários de Falha
- ❌ Produto indisponível
- ❌ Quantidade maior que estoque
- ❌ Cartão de crédito inválido
- ❌ CVV vazio ou inválido
- ❌ Cupom inválido (não impede o pedido)

## 🛠️ Tecnologias Utilizadas

- **.NET 9.0**
- **C# 12**
- **xUnit**
- **PowerShell** (para automação)

## 📝 Observações

- Os testes utilizam o padrão **Fact** para testes simples e **Theory** para testes parametrizados
- Todos os subsistemas são testados de forma isolada
- O OrderFacade é testado de ponta a ponta com diferentes cenários
- Os testes incluem validações de exceções e comportamentos esperados

---

**Desenvolvido como parte do Desafio Carnacode 2026 - Padrão Facade**

