using System.Text.RegularExpressions;

using Spectre.Console;
using Spectre.Console.Cli;

namespace Custom.CLI.Commands
{
    internal class RegexCommand : Command<RegexCommand.RegexCommandSettings>
    {
        public override int Execute(CommandContext context, RegexCommandSettings settings)
        {
            var input = string.Join(' ', settings.Input);
            var regex = new Regex(settings.Pattern);
            var matches = regex.Matches(input).Cast<Match>();
            if (matches.Any())
            {
                var table = new Table();
                table.AddColumn("匹配项");
                foreach (var match in matches)
                {
                    if (match != null)
                    {
                        table.AddRow("[green]" + match.Value + "[/]");
                    }
                }
                AnsiConsole.Write(table);
            }
            else
            {
                Console.WriteLine("无匹配项");
            }
            return 0;
        }

        public class RegexCommandSettings : CommandSettings
        {
            [CommandArgument(0, "[正则表达式]")]
            public string Pattern { get; set; }

            [CommandArgument(1, "[匹配字符串]")]
            public string[] Input { get; set; }
        }
    }
}