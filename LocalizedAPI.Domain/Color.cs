namespace dir.masterpan_erp.Bases
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Color(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}