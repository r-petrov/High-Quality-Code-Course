namespace Theatre.Interfaces
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This interface contains methods which add or list theatres or their perfomances.
    /// These methods are used for executing of the commands specified in the application's documentation.
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// The method creates a "theatre" object if there is not a theatre with that name in the collection of theatres and adds it to the collection.
        /// </summary>
        /// <param name="theatre">
        /// Theatre name - parameter which is used by the method for checking for a theatre with that name in the collection of theatres and then 
        /// for creation of new theatre.
        /// </param>
        void AddTheatre(string theatre);

        /// <summary>
        /// The method gets all theatre's names from the collection of theatres objects.
        /// If the collection of theatres's names is not empty orders it alphabetically.
        /// </summary>
        /// <returns>
        /// Collection of ordered strings which consists of theatres names.
        /// </returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// The method creates a "performance" object for specified theatre and adds it to theatre's timetable 
        /// if there is a theatre with that name in the collection of theatres and if there is not overlapping performances.
        /// </summary>
        /// <param name="theatre">
        /// Theatre name - the name of specified theatre which timetable will hold the new performance. 
        /// The parameter is also used by the method for check for a theatre with that name in the collection of theatres.
        /// </param>
        /// <param name="performance">
        /// The name of the new perfomance.
        /// </param>
        /// <param name="dateAndTime">
        /// The date and time when the new performance should start.
        /// </param>
        /// <param name="duration">The duration of the new perfomarmance.
        /// </param>
        /// <param name="price">
        /// The price of the new performance.
        /// </param>
        void AddPerformance(string theatre, string performance, DateTime dateAndTime, TimeSpan duration, decimal price);

        /// <summary>
        /// The method gets all the performances from all theatre's timetables. 
        /// If the collection of performances is not empty orders it by theatre (as first criteria) and by date and time (as second criteria).
        /// </summary>
        /// <returns>
        /// Collection of ordered perfomances.
        /// </returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// The method gets all the performances from the timetable of specified theatre if there is a theatre with that name in the collection of theatres. 
        /// If the collection of performances is not empty orders it by date and time.
        /// </summary>
        /// <param name="theatreName">
        /// The name of cpecified theatre which timetable's performances will be got.
        /// The parameter is also used by the method for check for a theatre with that name in the collection of theatres.
        /// </param>
        /// <returns>
        /// Collection of ordered perfomances from specified theatre's timetable.
        /// </returns>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}