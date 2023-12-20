using System.Text.RegularExpressions;

using Custom.Cli.Models;

namespace Custom.Cli.Commands
{
    public class RegexCommand : CommandBase
    {
        public override Task ExecuteAsync(CommandContext context)
        {
            var input = string.Join(' ', Input);
            var regex = new Regex(Pattern);
            var matches = regex.Matches(input).Cast<Match>();
            if (matches.Any())
            {
                Console.WriteLine("匹配项：");
                foreach (var match in matches)
                {
                    if (match != null)
                    {
                        Console.WriteLine("\t{0}", match.Value);
                    }
                }
            }
            else
            {
                Console.WriteLine("无匹配项");
            }
            return Task.CompletedTask;
        }

        [CliArgument(0, "正则表达式")]
        public string Pattern { get; set; }

        [CliArgument(1, "匹配字符串")]
        public string[] Input { get; set; }
    }
}