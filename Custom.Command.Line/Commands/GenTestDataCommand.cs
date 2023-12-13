using Custom.Command.Line.Utils;

namespace Custom.Command.Line.Commands
{
    internal class GenTestDataCommand : CommandBase
    {
        public override (string name, string desc) ID => ("gen", "生成常用测试数据");

        protected override Dictionary<(string, string), Action<string>> Options => new()
        {
            [("--phone", "手机号码")] = str => Console.WriteLine("11223456"),
            [("--snowid", "雪花ID")] = str => Console.WriteLine("雪花ID"),
        };

        public override Task ExecuteAsync(string[] args)
        {
            if (args.Length == 0 || !args[0].StartsWith("--"))
            {
                throw new ArgumentException(TipUtils.ArgumentError2);
            }
            GetOptionValue(args[0])?.Invoke("");
            return Task.CompletedTask;
        }
    }
}