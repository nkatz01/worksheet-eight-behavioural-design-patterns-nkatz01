using System;

namespace mediator
{
    public class CottonMediator : IMachineMediator
    {
        private const int DrumSpeed = 700;
        private const int Temperature = 40;
        private Machine machine { get; set; }
        private Heater heater { get; set; }
        private Motor motor { get; set; }
        private Sensor sensor { get; set; }
        private SoilRemoval soilRemoval { get; set; }
        private Valve valve { get; set; }

        public CottonMediator(Machine machine, Heater heater, Motor motor, Sensor sensor,
            SoilRemoval soilRemoval, Valve valve)
        {
            Console.WriteLine($"............... Setting up for COTTON program ...............");
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