using Custom.Cli;

using Spectre.Console;
using Spectre.Console.Json;

using TextCopy;

namespace Custom.Cli
{
    public class JsonViewCommand : CommandBase
    {
        public override Task ExecuteAsync(CommandContext context)
        {
            var text = ClipboardService.GetText();
            if (text != null)
            {
                text = text.Replace("\\", "");
                var json = new JsonText(text);

                AnsiConsole.Write(json);
            }
            return Task.CompletedTask;
        }
    }
}