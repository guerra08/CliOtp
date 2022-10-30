namespace CliOtp.Config;

public static class ConfigFiles
{
    private const string CliOtpConfigDirName = "cliotp";
    private const string ConfigFileName = "config.json";
    
    public static string ConfigFilePath() =>
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
        + Path.DirectorySeparatorChar
        + CliOtpConfigDirName
        + Path.DirectorySeparatorChar
        + ConfigFileName;
}