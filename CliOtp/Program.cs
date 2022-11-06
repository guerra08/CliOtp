using CliOtp.Core;
using CliOtp.Exceptions;
using CliOtp.Stores;
using Spectre.Console;

AnsiConsole.Write(
    new FigletText("CliOtp")
        .LeftAligned()
        .Color(Color.Orange1));

AnsiConsole.WriteLine("Manage your OTP tokens in the terminal!");

try
{
    var table = new Table().LeftAligned();

    var configurationEntries = OtpEntryStore.GetEntries();

    table.AddColumns("[bold]Name[/]", "[bold]Code[/]", "[bold]Time remaining[/]");

    await AnsiConsole.Live(table)
        .StartAsync(async ctx =>
        {
            var tasks = configurationEntries.Select(async (entry, index) =>
            {
                await table.OtpRoutine(entry, index, ctx);
            }).ToArray();
            await Task.WhenAll(tasks);
        });
    return 0;
}
catch (ConfigurationException e)
{
    AnsiConsole.Write(e.Message);
    return 1;
}