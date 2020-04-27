using System;
using System.Collections;
using System.Collections.Generic;

namespace iterator
{
 
    public class ShapeIterator<TShape> : IEnumerator<TShape>
        where TShape : ShapeStorage<Shape>
    {
        int position = -1;
        private Shape[] ShapeCollection;
        public ShapeIterator(TShape thing)
        {
             
              var ShapeStorage =  (ShapeStorage<Shape>)thing;
            ShapeCollection = ShapeStorage.GetShapes();
            //  Console.WriteLine(ShapeCollection[0].ToString());
        }

        public bool MoveNext()
        {
            position++;
            return (position < ShapeCollection.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public TShape Current {
            get;
        }

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            this.MoveNext();
        }
    }
}