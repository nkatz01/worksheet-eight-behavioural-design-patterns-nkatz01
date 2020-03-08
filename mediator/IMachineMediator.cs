namespace mediator
{
    public interface IMachineMediator
    {
        void Start();
        void Wash();
        void Open();
        void Closed();
        void On();
        void Off();
        bool CheckTemperature(int temp);
    }
}