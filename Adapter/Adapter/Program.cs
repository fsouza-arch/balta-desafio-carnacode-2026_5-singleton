using Adapter.Application.Services;
using Adapter.Infrastructure.Adapters;
using Adapter.Infrastructure.LegacySystem;

Console.WriteLine("=== Integração via Adapter ===\n");

// Usando o sistema legado de forma transparente!
var legacySystem = new LegacyPaymentSystem();
var adapter = new LegacyPaymentAdapter(legacySystem);

// O CheckoutService aceita o adapter porque ele implementa IPaymentProcessor
var checkout = new CheckoutService(adapter);

checkout.CompleteOrder("usuario@teste.com", 250.50m);