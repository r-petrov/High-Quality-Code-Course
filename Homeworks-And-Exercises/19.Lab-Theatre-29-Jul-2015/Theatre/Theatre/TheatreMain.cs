namespace Theatre
{
    using Core;
    using Interfaces;

    public class TheatreMain
    {
        public static void Main()
        {
            IOutputWriter consoleWriter = new ConsoleWriter();
            IPerformanceDatabase commandExecuter = new PerformanceDatabase(consoleWriter);
            ICommandDispatcher commandDispatcher = new CommandDispatcher(consoleWriter, commandExecuter);
            IEngine engine = new Engine(commandDispatcher);

            engine.Start();
        }
    }
}
