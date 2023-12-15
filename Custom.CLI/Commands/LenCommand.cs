using Spectre.Console.Cli;

namespace Custom.CLI.Commands
{
    internal class LenCommand : Command<LenCommand.LenCommandSettings>
    {
        public override int Execute(CommandContext context, LenCommandSettings settings)
        {
            Console.WriteLine(settings.Str?.Length ?? 0);
            return 0;
        }

        public class LenCommandSettings : CommandSettings
        {
            [CommandArgument(0, "[字符串]")]
            public string Str { get; set; }
        }
    }
}