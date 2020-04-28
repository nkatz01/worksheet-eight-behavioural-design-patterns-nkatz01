using System;
using System.Collections;
using System.Collections.Generic;

namespace iterator
{
 
    public class ShapeIterator<TShape> : IEnumerator<Shape>
      
    {
        public Shape Current
        {
            get
            {
                if (_position == -1) { 
                    _position++;
                    return ShapeCollection[_position];}

                try
                {
                    return ShapeCollection[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }

            }
        }

        private TShape<Shape> ShapeStorage;
        private Shape[] ShapeCollection;
        private int _position; 
        public ShapeIterator(TShape<Shape> thing)
        {

                ShapeStorage =   thing;

            ShapeCollection = thing.GetShapes();
            _position = -1; 
           
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < ShapeStorage.GetLength() ); 
        }

        public void Reset()
        {
            _position = -1;
        }

       

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            this.MoveNext();
        }
    }
}