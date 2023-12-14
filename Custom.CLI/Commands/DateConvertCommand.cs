using Custom.CLI.Utils;

using Spectre.Console.Cli;

namespace Custom.CLI.Commands
{
    internal class DateConvertCommand : Command<DateConvertCommand.DateConvertCommandSettings>
    {
        public override int Execute(CommandContext context, DateConvertCommandSettings settings)
        {
            Console.WriteLine(TimeUtils.ToTimestamp(settings.Date.Add(settings.Time)));
            return 0;
        }

        public class DateConvertCommandSettings : CommandSettings
        {
            [CommandArgument(0, "[日期]")]
            public DateTime Date { get; set; }

            [CommandArgument(1, "[时分秒]")]
            public TimeSpan Time { get; set; }
        }
    }
}