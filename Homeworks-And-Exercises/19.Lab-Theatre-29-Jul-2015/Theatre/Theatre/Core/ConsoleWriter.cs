namespace Theatre
{
    using System;
    using Interfaces;

    public class ConsoleWriter : IOutputWriter
    {
        public void Write(string msg)
        {
            Console.Write(msg);
        }

        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}