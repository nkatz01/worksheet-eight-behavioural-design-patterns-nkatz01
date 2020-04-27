namespace iterator
{
    public class ShapeStorage<T> where T : Shape, new()
    {
        private const int NumberOfShapes = 5;
        private readonly T[] _shapes = new T[NumberOfShapes];
        private int _index = 0;

        public void AddShape(string name) =>
            _shapes[_index++] = new T {Id = _index, Name = name};

        public Shape GetShapes()
        {
            return _shapes[_index];
        }

        public void Indexer(bool direction)
        {
            _index = direction ? +1 : -1;  

        }

        public int GetLength()
        {
            return NumberOfShapes; 
        }

        public int GetIndex()
        {
            return _index;
        }

        public void ResetIndex()
        {
            _index = 0;
        }
       
    }
}