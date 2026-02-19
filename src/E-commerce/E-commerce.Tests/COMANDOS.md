# 🧪 Guia de Comandos para Testes

## Comandos Básicos

### Executar todos os testes
```powershell
dotnet test
```

### Executar com saída detalhada
```powershell
dotnet test --verbosity normal
```

### Executar com saída mínima
```powershell
dotnet test --verbosity minimal
```

## Executar Testes Específicos

### Por classe de teste
```powershell
# Executar apenas testes do OrderFacade
dotnet test --filter "FullyQualifiedName~OrderFacadeTests"

# Executar apenas testes do InventorySystem
dotnet test --filter "FullyQualifiedName~InventorySystemTests"

# Executar apenas testes do PaymentGateway
dotnet test --filter "FullyQualifiedName~PaymentGatewayTests"
```

### Por método específico
```powershell
# Executar apenas um teste específico
dotnet test --filter "FullyQualifiedName~FinalizeOrder_ShouldReturnTrue_WhenOrderIsSuccessful"
```

### Por categoria ou padrão
```powershell
# Executar todos os testes que contém "Success" no nome
dotnet test --filter "Name~Success"

# Executar todos os testes que contém "Failed" no nome
dotnet test --filter "Name~Failed"
```

## Cobertura de Código

### Com Coverlet (após instalar o pacote)
```powershell
# Executar testes com cobertura
dotnet test /p:CollectCoverage=true

# Gerar relatório HTML de cobertura
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=html
```

## Testes com Logger

### Logger Console
```powershell
dotnet test --logger "console;verbosity=detailed"
```

### Logger TRX (para CI/CD)
```powershell
dotnet test --logger "trx;LogFileName=test-results.trx"
```

### Logger HTML
```powershell
dotnet test --logger "html;LogFileName=test-results.html"
```

## Executar em Modo Watch

### Modo watch (executa testes automaticamente ao salvar)
```powershell
dotnet watch test
```

## Restaurar e Compilar

### Restaurar dependências
```powershell
dotnet restore
```

### Compilar projeto
```powershell
dotnet build
```

### Restaurar + Compilar + Testar
```powershell
dotnet restore; dotnet build; dotnet test
```

## Exemplos Práticos

### 1. Executar apenas testes do subsistema de estoque
```powershell
cd C:\dev\carnacode-2026\balta-desafio-carnacode-2026_10-facade\src\E-commerce\E-commerce.Tests
dotnet test --filter "FullyQualifiedName~InventorySystemTests"
```

### 2. Executar apenas testes do Facade (integração)
```powershell
dotnet test --filter "FullyQualifiedName~OrderFacadeTests"
```

### 3. Executar testes de todos os subsistemas (exceto Facade)
```powershell
dotnet test --filter "FullyQualifiedName~SystemTests|FullyQualifiedName~GatewayTests|FullyQualifiedName~ServiceTests"
```

### 4. Executar com cobertura e gerar relatório
```powershell
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./coverage/
```

## Configurações Úteis

### Ver lista de testes sem executar
```powershell
dotnet test --list-tests
```

### Executar testes em paralelo (padrão)
```powershell
dotnet test --parallel
```

### Executar testes sequencialmente
```powershell
dotnet test --parallel none
```

### Executar com timeout
```powershell
dotnet test --timeout 60000  # 60 segundos
```

## Debugging

### Executar com informações de diagnóstico
```powershell
dotnet test --diag:log.txt
```

### Executar sem compilar (se já compilado)
```powershell
dotnet test --no-build
```

### Executar sem restaurar dependências
```powershell
dotnet test --no-restore
```

## CI/CD

### Exemplo para Azure DevOps / GitHub Actions
```powershell
dotnet restore
dotnet build --configuration Release --no-restore
dotnet test --configuration Release --no-build --verbosity normal --logger "trx;LogFileName=test-results.trx"
```

## Dicas

1. **Use `--filter`** para executar testes específicos durante o desenvolvimento
2. **Use `--verbosity`** para controlar o nível de detalhes
3. **Use `dotnet watch test`** para feedback instantâneo
4. **Use `--logger`** para integração com CI/CD
5. **Use cobertura de código** para identificar áreas não testadas

## Resumo Rápido

```powershell
# Desenvolvimento
dotnet watch test                                    # Modo watch
dotnet test --filter "FullyQualifiedName~Classe"    # Teste específico

# Build Completo
dotnet restore && dotnet build && dotnet test        # Tudo de uma vez

# CI/CD
dotnet test --logger "trx" --configuration Release  # Pipeline
```

---

**💡 Dica**: Use `dotnet test --help` para ver todas as opções disponíveis!

