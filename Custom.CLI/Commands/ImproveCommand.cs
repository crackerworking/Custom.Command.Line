using Newtonsoft.Json.Linq;

using Spectre.Console;
using Spectre.Console.Cli;

namespace Custom.CLI.Commands
{
    internal class ImproveCommand : Command
    {
        public override int Execute(CommandContext context)
        {
            var client = new HttpClient();
            var msg = client.GetAsync("https://hmajax.itheima.net/api/ambition").GetAwaiter().GetResult();
            var str = msg.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jo = JObject.Parse(str);
            AnsiConsole.Write(new Markup("[bold cyan1]" + jo["data"] + "[/]"));
            return 0;
        }
    }
}