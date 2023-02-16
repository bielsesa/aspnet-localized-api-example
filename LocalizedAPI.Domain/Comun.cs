namespace dir.masterpan_erp.Comunes
{
    public class Comun
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }

        public Comun(int id, string name, int quantity, double value)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Value = value;
        }

        public override string? ToString()
        {
            return $"El nombre de este común es {Name} y su cantidad es {Quantity}.{Environment.NewLine}" +
                $"Su valor individual es {Value}, y su valor total es {Quantity*Value}";
        }
    }
}
