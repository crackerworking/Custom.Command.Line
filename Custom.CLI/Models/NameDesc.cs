namespace Custom.CLI.Models
{
    internal class NameDesc
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public NameDesc(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
    }
}