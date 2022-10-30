using System.Text.Json;

namespace CliOtp.Config;

public static class ConfigReader
{
    public static T ReadConfig<T>(string path)
    {
        if (!File.Exists(path))
        {
            throw new ApplicationException();
        }

        var fileContents = File.ReadAllText(path);
        var result = JsonSerializer.Deserialize<T>(fileContents);
        if (result is null) throw new ApplicationException();
        return result;
    }
}