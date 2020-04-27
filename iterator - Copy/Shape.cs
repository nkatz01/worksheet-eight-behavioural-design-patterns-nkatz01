namespace iterator
{
    public class Shape  
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Shape(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Shape()
        {

        }

        public override string ToString() => $"ID: {Id} Shape: {Name}";
    }
}