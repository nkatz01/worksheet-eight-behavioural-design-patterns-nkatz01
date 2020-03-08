using System;

namespace mediator
{
    public static class TestMediator
    {
        public static void Main(string[] args)
        {
            var sensor = new Sensor();
            var soilRemoval = new SoilRemoval();
            var motor = new Motor();
            var machine = new Machine();
            var heater = new Heater();
            var valve = new Valve();
            var button = new Button();

            IMachineMediator mediator = new CottonMediator(machine, heater, motor, sensor, soilRemoval, valve);

            button.Mediator = mediator;
            machine.Mediator = mediator;
            heater.Mediator = mediator;
            valve.Mediator = mediator;

            button.Press();

            Console.WriteLine("********************");

            mediator = new DenimMediator(machine, heater, motor, sensor, soilRemoval, valve);
            button.Mediator = mediator;
            machine.Mediator = mediator;
            heater.Mediator = mediator;
            valve.Mediator = mediator;
            
            button.Press();
        }
    }
}