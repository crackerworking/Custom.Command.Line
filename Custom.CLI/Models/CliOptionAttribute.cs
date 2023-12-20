namespace Custom.Cli.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CliOptionAttribute(string name, string description) : Attribute
    {
        public string Name { get; private set; } = name;

        public string Description { get; private set; } = description;
    }
}