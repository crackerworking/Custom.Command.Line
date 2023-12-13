
namespace Custom.Command.Line
{
    internal class Program
    {
        /// <summary>
        /// "--"表示选项，例：--help；不支持子命令，命令后接参数或选项
        /// </summary>
        /// <param name="args"></param>
        private static async Task Main(string[] args)
        {
            if (args.Length == 0) return;
            var cmdBase = typeof(CommandBase);
            var cmds = typeof(Program).Assembly.DefinedTypes.Where(x => !x.IsAbstract && !x.IsInterface && x.IsAssignableTo(cmdBase));
            var cmd_dict = new Dictionary<string, CommandBase>();
            var desc_dict = new Dictionary<string, string>();
            foreach (var item in cmds)
            {
                var instance = (CommandBase?)Activator.CreateInstance(item);
                if (instance == null) continue;
                cmd_dict.TryAdd(instance.ID.name, instance);
                desc_dict.TryAdd(instance.ID.name, instance.ID.desc);
            }
            if (cmd_dict.TryGetValue(args[0], out var val))
            {
                var paras = args.ToList();
                paras.RemoveAt(0);
                await val.ExecuteAsync(paras.ToArray());
            }
        }
    }
}