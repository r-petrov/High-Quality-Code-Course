namespace Theatre.Exceptions
{
    using System;

    internal class NoTheatresException : Exception
    {
        public NoTheatresException(string msg) : base(msg)
        {
        }
    }
}