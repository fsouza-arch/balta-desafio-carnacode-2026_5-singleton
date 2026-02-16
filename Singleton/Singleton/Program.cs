using Singleton.Core;
using Singleton.Infrastructure.Services;

Console.WriteLine("=== Sistema de Configurações (Padrão Singleton) ===\n");

// Prova 1: Mesmo chamando vários serviços, o construtor só roda UMA vez
var dbService = new DatabaseService();
var apiService = new ApiService();
var logService = new LoggingService();

dbService.Connect();
apiService.MakeRequest();
logService.Log("Sistema rodando com Singleton");

// Prova 2: Consistência Global
Console.WriteLine("\n--- Atualização Global ---");

// Atualizamos em um lugar...
ConfigurationManager.Instance.UpdateSetting("LogLevel", "Debug");

// ...e o valor reflete em todos os outros lugares imediatamente!
logService.Log("Esta mensagem agora deve estar em modo Debug");

// Prova 3: Identidade de Instância
var instance1 = ConfigurationManager.Instance;
var instance2 = ConfigurationManager.Instance;

if (ReferenceEquals(instance1, instance2))
{
    Console.WriteLine("\n✅ SUCESSO: instance1 e instance2 são exatamente a mesma instância na memória!");
}