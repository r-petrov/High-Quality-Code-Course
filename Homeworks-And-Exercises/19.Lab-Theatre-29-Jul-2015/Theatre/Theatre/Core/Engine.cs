namespace Theatre.Core
{
    using System;
    using Interfaces;

    internal class Engine : IEngine
    {
        private const int NumberOfCommands = 50000;

        private ICommandDispatcher commandDispatcher;

        public Engine(ICommandDispatcher commandDispatcher)
        {
            this.CommandDispatcher = commandDispatcher;
        }

        public ICommandDispatcher CommandDispatcher
        {
            get
            {
                return this.commandDispatcher;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Command dispatcher can not be null");
                }

                this.commandDispatcher = value;
            }
        }

        public void Start()
        {
            for (int i = 0; i < NumberOfCommands; i++)
            {
                string commandLine = Console.ReadLine();
                if (string.IsNullOrEmpty(commandLine))
                {
                    continue;
                }

                if (commandLine != string.Empty)
                {
                    char[] separators = { '(', ',', ')' };
                    var commandData = commandLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    this.CommandDispatcher.DispatchCommand(commandData);
                }
            }
        }
    }
}
