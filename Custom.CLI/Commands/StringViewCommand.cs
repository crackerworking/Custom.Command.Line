using TextCopy;

namespace Custom.Cli.Commands
{
    internal class StringViewCommand : CommandBase
    {
        public override Task ExecuteAsync(CommandContext context)
        {
            var text = ClipboardService.GetText();
            if (text != null)
            {
                text = text.Replace("\r", "").Replace("\n", ",");
                text = string.Join(',', text.Split(',', StringSplitOptions.RemoveEmptyEntries));
            }
            Console.WriteLine("(" + text + ")");
            return Task.CompletedTask;
        }
    }
}