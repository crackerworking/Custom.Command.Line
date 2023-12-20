using Custom.Cli.Helpers;
using Custom.Cli.Models;

namespace Custom.Cli.Commands
{
    public class DateConvertCommand : CommandBase
    {
        public override Task ExecuteAsync(CommandContext context)
        {
            Console.WriteLine(TimeHelper.ToTimestamp(Date.Add(Time)));
            return Task.CompletedTask;
        }

        [CliArgument(0, "日期")]
        public DateTime Date { get; set; }

        [CliArgument(1, "时分秒")]
        public TimeSpan Time { get; set; }
    }
}