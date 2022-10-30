using CliOtp.Config;
using CliOtp.Data;

namespace CliOtp.Stores;

public static class OtpEntryStore
{

    private static readonly IList<OtpEntry> OtpEntries;

    static OtpEntryStore()
    {
        OtpEntries = ConfigReader
            .ReadConfig<ConfigData>(ConfigFiles.ConfigFilePath())
            .OtpEntries;
    }
    
    public static IEnumerable<OtpEntry> GetEntries()
    {
        return OtpEntries;
    }

    public static bool IsEmpty() => OtpEntries.Count == 0;

}
