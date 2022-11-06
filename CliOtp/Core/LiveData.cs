using System.Text;
using OtpNet;
using Spectre.Console;

namespace CliOtp.Core;

public static class LiveData
{
    public static async Task OtpRoutine(this Table table, OtpEntry entry, int tablePosition, LiveDisplayContext ctx)
    {
        var totp = new Totp(Encoding.ASCII.GetBytes(entry.Secret));
        var computedTotp = totp.ComputeTotp();
        var remainingSeconds = totp.RemainingSeconds();

        table.AddRow(entry.Name, computedTotp, $"{totp.RemainingSeconds()}s");

        while (remainingSeconds > 0)
        {
            table.UpdateCell(tablePosition, 1, computedTotp);
            table.UpdateCell(tablePosition, 2, $"{remainingSeconds}s");
            ctx.Refresh();
            await Task.Delay(1000 - DateTime.UtcNow.Millisecond);
            remainingSeconds = totp.RemainingSeconds();
            computedTotp = totp.ComputeTotp();
        }
    }
}