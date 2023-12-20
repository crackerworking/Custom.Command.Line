namespace Custom.Cli
{
    public abstract class CommandBase
    {
        public abstract Task ExecuteAsync(CommandContext context);
    }
}