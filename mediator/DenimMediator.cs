using System;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Threading;

namespace mediator
{
    public class DenimMediator : IMachineMediator
    {
        private const int DrumSpeed = 1400;
        private const int Temperature = 30;
        private Machine machine { get; set; }
        private Heater heater { get; set; }
        private Motor motor { get; set; }
        private Sensor sensor { get; set; }
        private SoilRemoval soilRemoval { get; set; }
        private Valve valve { get; set; }

        public DenimMediator(Machine machine, Heater heater, Motor motor, Sensor sensor,
            SoilRemoval soilRemoval, Valve valve)
        {
            Console.WriteLine($"............... Setting up for DENIM program ...............");
            throw new System.NotImplementedException();
        }

        public void Start() => machine.Start();

        public void Wash()
        {
            motor.StartMotor();
            motor.RotateDrum(DrumSpeed);

            Console.WriteLine("Adding detergent");
            soilRemoval.Low();
            Console.WriteLine("Adding softener");
        }

        public void Open() => valve.Open();

        public void Closed() => valve.Closed();

        public void On() => heater.On(Temperature);

        public void Off() => heater.Off();

        public bool CheckTemperature(int temp) => sensor.CheckTemperature(temp);
    }
}