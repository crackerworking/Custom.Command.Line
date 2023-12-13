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
            [CommandArgument(0, "[Target]")]
            public string Target { get; set; }
        }

        public override int Execute(CommandContext context, GenCommandSettings settings)
        {
            var r = new Random();
            var dict = new Dictionary<NameDesc, Action>
            {
                [new NameDesc("phone", "手机号码")] = () =>
                {
                    var sb = new StringBuilder(11).Append('1');
                    sb.Append(r.Next(3, 10));
                    for (int i = 0; i < 9; i++)
                    {
                        sb.Append(r.Next(0, 10));
                    }
                    Console.WriteLine(sb.ToString());
                },
                [new NameDesc("ts","当前时间戳")] = () =>
                {
                    Console.WriteLine(TimeUtils.CurrentTimestamp());
                }
            };
            if (settings.Target == "args")
            {
                foreach (var key in dict.Keys)
                {
                    Console.WriteLine("{0,-15}{1}", key.Name, key.Description);
                }
                return 0;
            }
            dict.FirstOrDefault(x => x.Key.Name == settings.Target).Value?.Invoke();
            return 0;
        }
    }
}