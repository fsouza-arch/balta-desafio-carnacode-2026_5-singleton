using Adapter.Dominio.Enums;
using Adapter.Dominio.Interfaces;
using Adapter.Dominio.Models;
using Adapter.Infrastructure.LegacySystem;

namespace Adapter.Infrastructure.Adapters;

public class LegacyPaymentAdapter : IPaymentProcessor
{
    private readonly LegacyPaymentSystem _legacySystem;

    public LegacyPaymentAdapter(LegacyPaymentSystem legacySystem)
    {
        _legacySystem = legacySystem;
    }

    public PaymentResult ProcessPayment(PaymentRequest request)
    {
        // TRADUÇÃO: Convertendo dados modernos para o formato legado
        int cvv = int.Parse(request.Cvv);
        double amountInCents = (double)(request.Amount * 100);

        // CHAMADA: Executando o método legado
        var legacyResponse = _legacySystem.AuthorizeTransaction(
            request.CreditCardNumber,
            cvv,
            request.ExpirationDate.Month,
            request.ExpirationDate.Year,
            amountInCents,
            request.CustomerEmail
        );

        // TRADUÇÃO DE VOLTA: Convertendo resposta legada para o formato moderno
        return new PaymentResult
        {
            Success = legacyResponse.ResponseCode == "00",
            TransactionId = legacyResponse.TransactionRef,
            Message = legacyResponse.ResponseMessage
        };
    }

    public bool RefundPayment(string transactionId, decimal amount)
    {
        return _legacySystem.ReverseTransaction(transactionId, (double)(amount * 100));
    }

    public PaymentStatus CheckStatus(string transactionId)
    {
        string status = _legacySystem.QueryTransactionStatus(transactionId);
        return status == "APPROVED" ? PaymentStatus.Approved : PaymentStatus.Declined;
    }
}