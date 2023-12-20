using GCore.Source.JsonClassGenerator;

using Spectre.Console;

using TextCopy;

namespace Custom.Cli.Commands
{
    internal class JsonToObjectConvertCommand : CommandBase
    {
        public override Task ExecuteAsync(CommandContext context)
        {
            var str = ClipboardService.GetText();
            if (str != null)
            {
                str = str.Trim();
                try
                {
                    var code = JsonClassGenerator.Generate(str, MainClass: "MainClass", Namespace: "TestNamespace", UseProperties: true).Trim();
                    ClipboardService.SetText(code);
                    AnsiConsole.Write(
                        new Panel(code)
                            .Header("C#对象已复制到剪贴板")
                            .Collapse()
                            .RoundedBorder()
                            .BorderColor(Color.Yellow));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("JSON格式错误：" + ex.Message);
                }
            }
            return Task.CompletedTask;
        }
    }
}