using CliOtp.Data;

namespace CliOtp.Stores;

public static class OtpEntryStore
{

    private static readonly IList<OtpEntry> _otpEntries = new List<OtpEntry>();

    public static void AddEntry(OtpEntry entry)
    {
        _otpEntries.Add(entry);
    }

    public static IReadOnlyList<OtpEntry> GetEntries()
    {
        return (IReadOnlyList<OtpEntry>)_otpEntries;
    }

}
