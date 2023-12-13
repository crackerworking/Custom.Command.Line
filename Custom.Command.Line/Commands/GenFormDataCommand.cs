namespace Custom.Command.Line.Commands
{
    internal class GenFormDataCommand : CommandBase
    {
        public override (string name, string desc) ID => ("gen", "生成常用测试数据");

        protected override List<CommandOption> Options => new()
        {
                new() {
                    Name = "--phone",
                    Action = () =>
                    {
                        Console.WriteLine("125467865321");
                    }
                }
        };

        public override Task ExecuteAsync(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("至少需要一个参数或选项");
                return Task.CompletedTask;
            }
            var option = Options.FirstOrDefault(x => x.Name == args[0]);
            option?.Action.Invoke();
            return Task.CompletedTask;
        }
    }
}