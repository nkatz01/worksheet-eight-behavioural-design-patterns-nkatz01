using System;

namespace mediator
{
    public class Machine : IColleague
    {
        public IMachineMediator Mediator { get; set; }
      //  public Drum Drum { get; set; }
     //   public Valve Valve { get; set; }
        public void Start() { 
            
            Mediator.Open();
            Console.WriteLine("Filling water...");
            Mediator.Closed();
            Mediator.On();
            Mediator.CheckTemperature();
            Mediator.Off();
            Mediator.Wash();
            Wash();
        }
        public void Wash() => Mediator.Wash();
    }
}