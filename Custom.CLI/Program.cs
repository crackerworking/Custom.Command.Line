using Custom.CLI.Commands;

using Spectre.Console.Cli;

namespace Custom.CLI
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var app = new CommandApp();
            app.Configure(config =>
            {
                config.AddCommand<GenCommand>("gen").WithDescription("生成常用测试数据");
            });
            await app.RunAsync(args);
        }
    }
}