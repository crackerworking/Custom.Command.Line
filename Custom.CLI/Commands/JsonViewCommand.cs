using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Json;

using TextCopy;

namespace Custom.CLI.Commands
{
    internal class JsonViewCommand : Command
    {
        public override int Execute(CommandContext context)
        {
            var text = ClipboardService.GetText();
            if (text != null)
            {
                text = text.Replace("\\", "");
                var json = new JsonText(text);

                AnsiConsole.Write(json);
            }
            return 0;
        }
    }
}