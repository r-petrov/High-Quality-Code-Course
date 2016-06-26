namespace Theatre.Interfaces
{
    public interface ICommandDispatcher
    {
        IOutputWriter OutputWriter { get; set; }

        void DispatchCommand(string[] commandData);
    }
}