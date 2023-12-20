using System.Text;

using Custom.Cli.Helpers;
using Custom.Cli.Models;
using Custom.CLI.Models;

namespace Custom.Cli.Commands
{
    public class GenCommand : CommandBase
    {
        [CliArgument(0, "phone|timestamp|idno|guid|snowid", required: true)]
        public string Target { get; set; }

        public override Task ExecuteAsync(CommandContext context)
        {
            var r = new Random();
            var dict = new Dictionary<string, Action>
            {
                ["phone"] = () =>
                {
                    var sb = new StringBuilder(11).Append('1');
                    sb.Append(r.Next(3, 10));
                    for (int i = 0; i < 9; i++)
                    {
                        sb.Append(r.Next(0, 10));
                    }
                    Console.WriteLine(sb.ToString());
                },
                ["timestamp"] = () =>
                {
                    Console.WriteLine(TimeHelper.CurrentTimestamp());
                },
                ["idno"] = () =>
                {
                    var str = GenHelper.GenAsync().ConfigureAwait(true).GetAwaiter().GetResult();
                    Console.WriteLine(str);
                },
                ["guid"] = () =>
                {
                    Console.WriteLine(Guid.NewGuid());
                },
                ["snowid"] = () =>
                {
                    var ins = new SnowflakeId(1, 4);
                    Console.WriteLine(ins.NextId());
                }
            };
            if (!string.IsNullOrWhiteSpace(Target) && dict.TryGetValue(Target, out var action))
            {
                action?.Invoke();
            }
            return Task.CompletedTask;
        }
    }
}