using System.Text.Json;
using CliOtp.Exceptions;

namespace CliOtp.Config;

public static class ConfigReader
{
    public static T ReadConfig<T>(string path)
    {
        if (!File.Exists(path)) throw new ConfigurationException("Unable to find configuration file for CliOtp.");

        var fileContents = File.ReadAllText(path);
        var result = JsonSerializer.Deserialize<T>(fileContents);
        if (result is null) throw new ApplicationException("Unable to parse configuration file.");
        return result;
    }
}