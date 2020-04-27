using System;
using System.Collections;
using System.Collections.Generic;

namespace iterator
{
 
    public class ShapeIterator<TShape> : IEnumerator<TShape>
       where TShape : ShapeStorage<Shape>
    {
       // int position = -1;
        private TShape ShapeCollection;
        public ShapeIterator(TShape thing)
        {

            // var ShapeStorage =  (ShapeStorage<Shape>)thing;
            //  ShapeCollection = thing.GetShapes();
            ShapeCollection = thing;
            //  Console.WriteLine(ShapeCollection[0].ToString());
        }

        public bool MoveNext()
        {
            // position++;
            // return (position < ShapeCollection.Length);
            ShapeCollection.Indexer(true);
            return (ShapeCollection.GetLength() < ShapeCollection.GetIndex()); 
        }

        public void Reset()
        {
            ShapeCollection.ResetIndex();
        }

        public TShape Current {
            get;
        }

        // object? IEnumerator.Current => Current;
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