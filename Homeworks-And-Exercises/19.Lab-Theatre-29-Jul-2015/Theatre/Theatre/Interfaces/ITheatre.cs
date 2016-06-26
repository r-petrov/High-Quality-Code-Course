namespace Theatre.Interfaces
{
    using System.Collections.Generic;

    public interface ITheatre
    {
        string Name { get; set; }

        ICollection<Performance> Timetable { get; set; }
    }
}