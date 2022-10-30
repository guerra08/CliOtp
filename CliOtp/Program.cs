using CliOtp.Core;
using CliOtp.Stores;
using Spectre.Console;

AnsiConsole.Write(
    new FigletText("CliOtp")
    .LeftAligned()
    .Color(Color.Orange1));

AnsiConsole.WriteLine("Manage your OTP tokens in the terminal!");

var table = new Table().LeftAligned();

table.AddColumns("[bold]Name[/]", "[bold]Code[/]", "[bold]Time remaining[/]");

await AnsiConsole.Live(table)
    .StartAsync(async ctx =>
    {
        var tasks = OtpEntryStore.GetEntries()
            .Select(async (entry, index) =>
            {
                await LiveData.OtpRoutine(table, ctx, entry, index);
            })
            .ToArray();

        await Task.WhenAll(tasks);
    });

return 0;