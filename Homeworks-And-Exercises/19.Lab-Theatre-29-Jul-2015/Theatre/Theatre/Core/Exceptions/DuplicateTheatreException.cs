namespace Theatre.Exceptions
{
    using System;

    internal class DuplicateTheatreException : Exception
    {
        public DuplicateTheatreException(string msg)
            : base(msg)
        {
        }
    }
}
