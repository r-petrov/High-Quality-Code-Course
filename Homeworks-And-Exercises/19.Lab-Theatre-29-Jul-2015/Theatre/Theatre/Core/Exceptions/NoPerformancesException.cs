namespace Theatre.Exceptions
{
    using System;

    internal class NoPerformancesException : Exception
    {
        public NoPerformancesException(string msg) : base(msg)
        {
        }
    }
}