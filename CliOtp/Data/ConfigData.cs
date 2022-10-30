using System.Text.Json.Serialization;

namespace CliOtp.Data;

public class ConfigData
{
    [JsonPropertyName("otpEntries")]
    public IList<OtpEntry> OtpEntries { get; set; }
}