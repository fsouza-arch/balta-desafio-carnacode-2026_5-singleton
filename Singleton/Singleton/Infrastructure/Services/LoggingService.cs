using Singleton.Core;

namespace Singleton.Infrastructure.Services;

public class LoggingService
{
    public void Log(string message)
    {
        var config = ConfigurationManager.Instance;
        var logLevel = config.GetSetting("LogLevel");
        Console.WriteLine($"[LoggingService] [{logLevel}] {message}");
    }
}
