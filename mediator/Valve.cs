namespace mediator
{
    public class Valve : IColleague
    {
        public IMachineMediator Mediator { get; set; }
        public void Open() => throw new System.NotImplementedException();
        public void Closed() => throw new System.NotImplementedException();
    }
}