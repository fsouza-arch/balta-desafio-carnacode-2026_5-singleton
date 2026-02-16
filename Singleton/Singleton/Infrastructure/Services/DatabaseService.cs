using Singleton.Core;

namespace Singleton.Infrastructure.Services;

public class DatabaseService
{
    public void Connect()
    {
        var config = ConfigurationManager.Instance;
        var connectionString = config.GetSetting("DatabaseConnection");
        Console.WriteLine($"[DatabaseService] Usando instância compartilhada para conectar: {connectionString}");
    }
}
