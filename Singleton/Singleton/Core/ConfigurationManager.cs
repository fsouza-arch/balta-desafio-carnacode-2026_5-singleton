namespace Singleton.Core;

public sealed class ConfigurationManager
{
    private static ConfigurationManager _instance;

    // Objeto de lock para garantir Thread-Safety
    private static readonly object _lock = new object();

    private Dictionary<string, string> _settings;
    private bool _isLoaded;

    // Impedir o uso do 'new' fora da classe
    private ConfigurationManager()
    {
        _settings = new Dictionary<string, string>();
        _isLoaded = false;
        Console.WriteLine("⚠️ Instância ÚNICA de ConfigurationManager criada!");
    }

    public static ConfigurationManager Instance
    {
        get
        {
            // Double-Check Locking para performance em ambientes multi-thread
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }
            return _instance;
        }
    }

    public void LoadConfigurations()
    {
        if (_isLoaded) return;

        lock (_lock) // Garante que dois threads não carreguem ao mesmo tempo
        {
            if (_isLoaded) return;

            Console.WriteLine("🔄 Carregando configurações globais...");
            Thread.Sleep(200); // Simula custo

            _settings["DatabaseConnection"] = "Server=localhost;Database=MyApp;";
            _settings["ApiKey"] = "abc123xyz789";
            _settings["CacheServer"] = "redis://localhost:6379";
            _settings["MaxRetries"] = "3";
            _settings["TimeoutSeconds"] = "30";
            _settings["EnableLogging"] = "true";
            _settings["LogLevel"] = "Information";

            _isLoaded = true;
            Console.WriteLine("✅ Configurações carregadas com sucesso!\n");
        }
    }

    public string GetSetting(string key)
    {
        if (!_isLoaded) LoadConfigurations();
        return _settings.ContainsKey(key) ? _settings[key] : null;
    }

    public void UpdateSetting(string key, string value)
    {
        lock (_lock)
        {
            _settings[key] = value;
            Console.WriteLine($"[Singleton] Configuração atualizada: {key} = {value}");
        }
    }
}