using Singleton.Core;

namespace Singleton.Infrastructure.Services;

public class ApiService
{
    public void MakeRequest()
    {
        var config = ConfigurationManager.Instance;
        var apiKey = config.GetSetting("ApiKey");
        Console.WriteLine($"[ApiService] Usando instância compartilhada para API: {apiKey}");
    }
}
