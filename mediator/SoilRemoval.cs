using System;

namespace mediator
{
    public class SoilRemoval
    {
        public void Low() => Console.WriteLine("Setting Soil Removal to low");  
        public void Medium() => Console.WriteLine("Setting Soil Removal to medium");
        public void High() => Console.WriteLine("Setting Soil Removal to high");
    }
}