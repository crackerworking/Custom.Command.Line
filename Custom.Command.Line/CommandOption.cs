namespace Custom.Command.Line
{
    internal class CommandOption
    {
        public string Name { get; set; }

        public Action Action { get; set; }
    }
}