using Newtonsoft.Json.Linq;

namespace Custom.Cli.Commands
{
    public class ImproveCommand : CommandBase
    {
        public override Task ExecuteAsync(CommandContext context)
        {
            var client = new HttpClient();
            var msg = client.GetAsync("https://hmajax.itheima.net/api/ambition").GetAwaiter().GetResult();
            var str = msg.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jo = JObject.Parse(str);
            Console.WriteLine(jo["data"]);
            return Task.CompletedTask;
        }
    }
}