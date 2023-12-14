using Custom.CLI.Utils;

using Spectre.Console.Cli;

namespace Custom.CLI.Commands
{
    internal class TimestampConvertCommand : Command<TimestampConvertCommand.TimestampConvertCommandSettings>
    {
        public override int Execute(CommandContext context, TimestampConvertCommandSettings settings)
        {
            Console.WriteLine(TimeUtils.ToTime(settings.Ts).ToString("yyyy-MM-dd HH:mm:ss"));
            return 0;
        }

        public class TimestampConvertCommandSettings : CommandSettings
        {
            [CommandArgument(0, "[时间戳]")]
            public long Ts { get; set; }
        }
    }
}