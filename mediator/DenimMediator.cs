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
            this.machine = machine;
            this.heater = heater;
            this.motor = motor;
            this.sensor = sensor;
            this.soilRemoval = soilRemoval;
            this.valve = valve;
        }

        public void Start() => machine.Start();

        public void Wash()
        {
            motor.StartMotor();
            motor.RotateDrum(DrumSpeed);

            Console.WriteLine("Adding detergent");
            soilRemoval.Medium();
            Console.WriteLine("Adding softener");
        }

        public void Open() => valve.Open();

        public void Closed() => valve.Closed();

        public void On() => heater.On(Temperature);

        public void Off() => heater.Off();

        public bool CheckTemperature() => sensor.CheckTemperature(30);
    }
}