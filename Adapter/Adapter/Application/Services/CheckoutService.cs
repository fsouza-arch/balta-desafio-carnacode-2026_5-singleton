using Adapter.Dominio.Interfaces;
using Adapter.Dominio.Models;

namespace Adapter.Application.Services;

public  class CheckoutService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public CheckoutService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

    public void CompleteOrder(string email, decimal amount)
    {
        var request = new PaymentRequest
        {
            CustomerEmail = email,
            Amount = amount,
            CreditCardNumber = "4111...",
            Cvv = "123",
            ExpirationDate = DateTime.Now.AddYears(2)
        };

        var result = _paymentProcessor.ProcessPayment(request);
        Console.WriteLine(result.Success ? $"✅ Sucesso! ID: {result.TransactionId}" : "❌ Falha!");
    }
}
