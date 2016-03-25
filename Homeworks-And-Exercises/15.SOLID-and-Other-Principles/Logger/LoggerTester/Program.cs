using Logger.Layouts;

namespace LoggerTester
{
    using Logger.Appenders;

    class Program
    {
        static void Main(string[] args)
        {
            var xmlLayout = new XmlLayout();
            var consoleAppender = new ConsoleAppender(xmlLayout);
            var logger = new Logger.Loggers.Logger(consoleAppender);

            logger.Fatal("mscorlib.dll does not respond");
            logger.Critical("No connection string found in App.config");
        }
    }
}
