using Adapter.Dominio.Enums;
using Adapter.Dominio.Models;

namespace Adapter.Dominio.Interfaces;

public interface IPaymentProcessor
{
    PaymentResult ProcessPayment(PaymentRequest request);
    bool RefundPayment(string transactionId, decimal amount);
    PaymentStatus CheckStatus(string transactionId);
}
