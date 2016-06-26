namespace Theatre.Interfaces
{
    public interface IEngine
    {
        ICommandDispatcher CommandDispatcher { get; set; }

        void Start();
    }
}