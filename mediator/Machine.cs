namespace mediator
{
    public class Machine : IColleague
    {
        public IMachineMediator Mediator { get; set; }

        public void Start() => throw new System.NotImplementedException();
        public void Wash() => throw new System.NotImplementedException();
    }
}