using CliOtp.Stores;
using CliOtp.Data;
using OtpNet;
using Spectre.Console;
using System.Text;

AnsiConsole.Write(
    new FigletText("CliOtp")
    .LeftAligned()
    .Color(Color.Orange1));

OtpEntryStore.AddEntry(new OtpEntry { Name = "Amazon", Secret = "abc123" });
OtpEntryStore.AddEntry(new OtpEntry { Name = "Google", Secret = "123abc" });

var table = new Table().Centered();

table.AddColumns("Name", "Code", "Time remaining");

await AnsiConsole.Live(table)
    .StartAsync(async ctx =>
    {
        var tasks = OtpEntryStore.GetEntries()
            .Select(async (entry, index) =>
            {
                await LiveDataRoutine(table, ctx, entry, index);
            })
            .ToArray();

        await Task.WhenAll(tasks);
    });

async Task LiveDataRoutine(
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