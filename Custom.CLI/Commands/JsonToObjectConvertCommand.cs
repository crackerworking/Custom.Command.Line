using GCore.Source.JsonClassGenerator;

using Spectre.Console;
using Spectre.Console.Cli;

using TextCopy;

namespace Custom.CLI.Commands
{
    internal class JsonToObjectConvertCommand : Command
    {
        public override int Execute(CommandContext context)
        {
            var str = ClipboardService.GetText();
            if (str != null)
            {
                str = str.Trim();
                try
                {
                    var code = JsonClassGenerator.Generate(str, MainClass: "MainClass", Namespace: "TestNamespace").Trim();
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
            return 0;
        }
    }
}