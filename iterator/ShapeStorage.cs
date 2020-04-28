namespace iterator
{
    public class ShapeStorage<T> : TShape<T> where T : Shape, new()
    {
        private const int NumberOfShapes = 5;
        private readonly T[] _shapes = new T[NumberOfShapes];
        private int _index = 0;

        public void AddShape(string name) =>
            _shapes[_index++] = new T {Id = _index, Name = name};

        public T[] GetShapes()
        {
            return _shapes;

        }

       

        public int GetLength()
        {
            return NumberOfShapes; 
        }

       

       
       
    }
}