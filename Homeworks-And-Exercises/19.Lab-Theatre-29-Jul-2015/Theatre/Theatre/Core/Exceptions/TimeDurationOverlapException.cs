namespace Theatre.Exceptions
{
    using System;

    internal class TimeDurationOverlapException : Exception
    {
        public TimeDurationOverlapException(string msg) : base(msg)
        {
        }
    }
}
