using System.Text;

using Custom.CLI.Models;
using Custom.CLI.Utils;

using Spectre.Console.Cli;

namespace Custom.CLI.Commands
{
    internal class GenCommand : Command<GenCommand.GenCommandSettings>
    {
        public class GenCommandSettings : CommandSettings
        {
            [CommandArgument(0, "[phone|timestamp|idno|guid|snowid]")]
            public string Target { get; set; }
        }

        public override int Execute(CommandContext context, GenCommandSettings settings)
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
                    Console.WriteLine(TimeUtils.CurrentTimestamp());
                },
                ["idno"] = () =>
                {
                    var str = IdNoUtils.GenAsync().ConfigureAwait(false).GetAwaiter().GetResult();
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
            if (dict.TryGetValue(settings.Target, out var action))
            {
                action?.Invoke();
            }
            return 0;
        }
    }
}