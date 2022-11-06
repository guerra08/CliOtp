using System.Text.Json.Serialization;
using CliOtp.Core;

namespace CliOtp.Config;

public record Configuration([property: JsonPropertyName("entries")]
    IEnumerable<OtpEntry> OtpEntries);