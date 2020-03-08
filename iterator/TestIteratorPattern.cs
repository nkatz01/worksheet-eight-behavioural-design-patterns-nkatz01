using System;

namespace iterator
{
    public static class TestIteratorPattern
    {
        public static void Main(string[] args)
        {
            var storage = new ShapeStorage<Shape>();
            storage.AddShape("Polygon");
            storage.AddShape("Hexagon");
            storage.AddShape("Circle");
            storage.AddShape("Rectangle");
            storage.AddShape("Square");

            var iterator = new ShapeIterator<ShapeStorage<Shape>>(storage);

            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }

            Console.WriteLine("Removing items while iterating...");
            iterator.Reset(); // reposition the iterator

            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
                iterator.Dispose();
            }
        }
    }
}