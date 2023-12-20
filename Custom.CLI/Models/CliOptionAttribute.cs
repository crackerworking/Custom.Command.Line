namespace Custom.Cli.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CliOptionAttribute(string name, string description) : Attribute
    {
        public string Name => name;

        public string Description => description;
    }
}