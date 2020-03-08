namespace mediator
{
    public class Heater : IColleague
    {
        public IMachineMediator Mediator { get; set; }

        public void On(int temp) => throw new System.NotImplementedException();
        public void Off() => throw new System.NotImplementedException();
    }
}