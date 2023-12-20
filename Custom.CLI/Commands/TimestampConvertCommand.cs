using Custom.Cli.Helpers;
using Custom.Cli.Models;

namespace Custom.Cli.Commands
{
    internal class TimestampConvertCommand : CommandBase
    {
        public override Task ExecuteAsync(CommandContext context)
        {
            Console.WriteLine(TimeHelper.ToTime(Ts).ToString("yyyy-MM-dd HH:mm:ss"));
            return Task.CompletedTask;
        }

        [CliArgument(0, "[时间戳]")]
        public long Ts { get; set; }
    }
}