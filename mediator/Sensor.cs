using System;

namespace mediator
{
    public class Sensor
    {
        public bool CheckTemperature(int temp) {
            Console.WriteLine($"Temperature reached {temp} C");
            Console.WriteLine($"Temperature is set to {temp}");
            return true;


                }
    }
}