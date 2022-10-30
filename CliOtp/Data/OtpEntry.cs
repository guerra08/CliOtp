using System.Text.Json.Serialization;

namespace CliOtp.Data;

public sealed class OtpEntry
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("secret")]
    public string Secret { get; set; }
}
