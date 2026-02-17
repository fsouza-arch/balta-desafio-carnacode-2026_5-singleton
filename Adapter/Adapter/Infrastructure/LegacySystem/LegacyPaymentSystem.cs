namespace Adapter.Infrastructure.LegacySystem;

public class LegacyPaymentSystem
{
    public LegacyTransactionResponse AuthorizeTransaction(string cardNum, int cvvCode, int expMonth, int expYear, double amountInCents,
        string customerInfo)
    {
        Console.WriteLine($"[Sistema Legado] Processando via API antiga...");
        return new LegacyTransactionResponse
        {
            AuthCode = "LEG123",
            ResponseCode = "00",
            ResponseMessage = "APPROVED",
            TransactionRef = $"LEG_{DateTime.Now.Ticks}"
        };
    }

    public bool ReverseTransaction(string transRef, double amountInCents) => true;

    public string QueryTransactionStatus(string transRef) => "APPROVED";
}
