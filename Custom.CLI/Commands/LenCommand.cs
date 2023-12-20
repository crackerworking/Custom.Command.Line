
using Custom.Cli.Models;

namespace Custom.Cli.Commands
{
    public class LenCommand : CommandBase
    {
        public override Task ExecuteAsync(CommandContext context)
        {
            Console.WriteLine(Str?.Length ?? 0);
            return Task.CompletedTask;
        }

        [CliArgument(0, "[字符串]")]
        public string Str { get; set; }
    }
}