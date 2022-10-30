using System.Text;
using CliOtp.Data;
using OtpNet;
using Spectre.Console;

namespace CliOtp.Core;

public static class LiveData
{
    public static async Task OtpRoutine(
        Table table,
        LiveDisplayContext ctx,
        OtpEntry entry,
        int tablePosition)
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