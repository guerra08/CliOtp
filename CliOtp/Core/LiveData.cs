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
        int position)
    {
        var totp = new Totp(Encoding.ASCII.GetBytes(entry.Secret));
        table.AddRow(entry.Name, totp.ComputeTotp(), $"{totp.RemainingSeconds()}s");
        while (totp.RemainingSeconds() > 0)
        {
            table.UpdateCell(position, 1, totp.ComputeTotp());
            table.UpdateCell(position, 2, $"{totp.RemainingSeconds()}s");
            ctx.Refresh();
            await Task.Delay(1000 - DateTime.UtcNow.Millisecond);
        }
    }
}