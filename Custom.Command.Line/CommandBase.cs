namespace Custom.Command.Line
{
    internal abstract class CommandBase
    {
        public abstract (string name, string desc) ID { get; }

        protected virtual List<CommandOption> Options { get; }

        public abstract Task ExecuteAsync(string[] args);
    }
}