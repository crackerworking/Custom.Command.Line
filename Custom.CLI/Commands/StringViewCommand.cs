using Spectre.Console.Cli;

using TextCopy;

namespace Custom.CLI.Commands
{
    internal class StringViewCommand : Command
    {
        public override int Execute(CommandContext context)
        {
            var text = ClipboardService.GetText();
            if (text != null)
            {
                text = text.Replace("\r", "").Replace("\n", ",");
                text = string.Join(',', text.Split(',', StringSplitOptions.RemoveEmptyEntries));
            }
            Console.WriteLine("(" + text + ")");
            return 0;
        }
    }
}