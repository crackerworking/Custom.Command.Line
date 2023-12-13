namespace Custom.Command.Line
{
    internal abstract class CommandBase
    {
        public abstract (string name, string desc) ID { get; }

        protected virtual Dictionary<(string name,string desc), Action<string>> Options { get; }

        protected virtual Dictionary<string, string> Parameters { get; }

        protected Action<string>? GetOptionValue(string name)
        {
            return Options.FirstOrDefault(x => x.Key.name == name).Value;
        }

        public abstract Task ExecuteAsync(string[] args);
    }
}