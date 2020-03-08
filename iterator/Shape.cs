namespace iterator
{
    public class Shape
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Shape(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Shape()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString() => $"ID: {Id} Shape: {Name}";
    }
}