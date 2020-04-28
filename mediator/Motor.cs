using System;

namespace mediator
{
    public class Motor
    {
        public void StartMotor() =>   Console.WriteLine("Start motor...");
           
        

        

        public void RotateDrum(int rpm) => Console.WriteLine($"Rotating drum at {rpm} rpm.");
    }
}