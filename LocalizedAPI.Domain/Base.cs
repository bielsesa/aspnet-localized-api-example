namespace dir.masterpan_erp.Bases
{
    public class Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }

        public Base(int id, string name, string description, Color color)
        {
            Id = id;
            Name = name;
            Description = description;
            Color = color;
        }

        public override string? ToString()
        {
            return $"Esta base se llama {Name}, su color es {Color} y su descripción " +
                $"es la siguiente:{Environment.NewLine}{Description}";
        }
    }
}