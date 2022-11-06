using CliOtp.Config;
using CliOtp.Core;

namespace CliOtp.Stores;

public static class OtpEntryStore
{
    private static readonly IEnumerable<OtpEntry> Entries =
        ConfigReader
            .ReadConfig<Configuration>(ConfigFiles.ConfigFilePath())
            .OtpEntries;

    public static IEnumerable<OtpEntry> GetEntries()
    {
        return Entries;
    }
}