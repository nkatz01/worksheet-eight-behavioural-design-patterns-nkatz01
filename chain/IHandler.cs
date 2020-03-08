namespace worksheet_eight_behavioural_design_patterns
{
    public interface IHandler
    {
        IHandler Handler { get; set; }
        void Process(object file);
    }
}