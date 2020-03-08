using System.Collections;
using System.Collections.Generic;

namespace iterator
{
    public class ShapeIterator<TShape> : IEnumerator<TShape>
    {
        public ShapeIterator(TShape thing)
        {
            throw new System.NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public TShape Current { get; }

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}