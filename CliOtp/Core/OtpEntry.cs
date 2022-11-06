using System.Text.Json.Serialization;

namespace CliOtp.Core;

public record OtpEntry(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("secret")] string Secret);