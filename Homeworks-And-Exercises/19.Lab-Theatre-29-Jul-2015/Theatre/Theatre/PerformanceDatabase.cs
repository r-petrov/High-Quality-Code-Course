namespace Theatre
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Interfaces;

    internal class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly ICollection<ITheatre> theatres;

        public PerformanceDatabase(IOutputWriter outputWriter)
        {
            this.theatres = new List<ITheatre>();
            this.OutputWriter = outputWriter;
        }

        public IOutputWriter OutputWriter { get; }

        public void AddTheatre(string theatre)
        {
            var theatreExists = this.CheckForTheatresExisting(this.theatres, theatre);
            if (theatreExists)
            {
                throw new DuplicateTheatreException(GlobalMessages.DuplicateTheatre);
            }
            
            var theatreToAdd = new Theatre(theatre);
            this.theatres.Add(theatreToAdd);
            var message = GlobalMessages.TheatreAdded;
            this.OutputWriter.WriteLine(message);
        }

        public IEnumerable<string> ListTheatres()
        {
            if (this.theatres.Count == 0)
            {
                throw new NoTheatresException(GlobalMessages.NoTheatres);
            }

            ICollection<string> theatresList = new List<string>();
            foreach (var theater in this.theatres)
            {
                theatresList.Add(theater.Name);
            }

            IEnumerable<string> sortedTheatresList = theatresList.OrderBy(th => th).ToList();

            return sortedTheatresList;
        }

        public void AddPerformance(string theatre, string performance, DateTime dateAndTime, TimeSpan duration, decimal price)
        {
            var theatreExists = this.CheckForTheatresExisting(this.theatres, theatre);
            if (!theatreExists)
            {
                throw new TheatreNotFoundException(GlobalMessages.TheatreDoesNotExist);
            }

            var currentTheatre = this.theatres.First(th => th.Name == theatre);
            var performances = currentTheatre.Timetable;
            var performanceEndTime = dateAndTime + duration;
            if (this.CheckForPerformancesOverlapping(performances, dateAndTime, performanceEndTime))
            {
                throw new TimeDurationOverlapException(GlobalMessages.TimeDurationOverlap);
            }

            var perfromanceToAdd = new Performance(theatre, performance, dateAndTime, duration, price);
            performances.Add(perfromanceToAdd);

            this.OutputWriter.WriteLine(GlobalMessages.PerformanceAdded);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            ICollection<Performance> performances = new List<Performance>();
            foreach (var theatre in this.theatres)
            {
                var theatrePerformances = theatre.Timetable;
                if (theatrePerformances.Count > 0)
                {
                    foreach (var theatrePerformance in theatrePerformances)
                    {
                        performances.Add(theatrePerformance);
                    }
                }
            }

            if (performances.Count == 0)
            {
                throw new NoPerformancesException(GlobalMessages.NoPerformances);
            }

            var orderedPerformances = performances
                .OrderBy(p => p.Theatre)
                .ThenBy(p => p.DateAndTime);

            return orderedPerformances;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            var theatreExists = this.CheckForTheatresExisting(this.theatres, theatreName);
            if (!theatreExists)
            {
                throw new TheatreNotFoundException(GlobalMessages.TheatreDoesNotExist);
            }

            var currentTheatre = this.theatres.First(th => th.Name == theatreName);
            if (currentTheatre.Timetable.Count == 0)
            {
                throw new NoPerformancesException(GlobalMessages.NoPerformances);
            }

            var performances = currentTheatre.Timetable;
            var orderedPerformances = performances.OrderBy(p => p.DateAndTime);

            return orderedPerformances;
        }

        private bool CheckForTheatresExisting(ICollection<ITheatre> theatres, string theatreName)
        {
            if (theatres.Count > 0)
            {
                foreach (var theatre in theatres)
                {
                    if (theatre.Name == theatreName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckForPerformancesOverlapping(
            ICollection<Performance> performances,
            DateTime addingPerformanceStartTime, 
            DateTime addingPerformanceEndTime)
        {
            foreach (var p in performances)
            {
                var existingPerformanceStartTime = p.DateAndTime;
                var existingPerformanceEndTime = p.DateAndTime + p.Duration;
                var isAddingPerformanceStartTimeDuringExistingPerformance = existingPerformanceStartTime <= addingPerformanceStartTime
                                                                             && addingPerformanceStartTime <= existingPerformanceEndTime;
                var isAddingPerformanceEndTimeDuringExistingPerformance = existingPerformanceStartTime <= addingPerformanceEndTime
                                                                           && addingPerformanceEndTime <= existingPerformanceEndTime;
                var isAddingPerformanceOverlappingExistingPeformance = addingPerformanceStartTime <= existingPerformanceStartTime
                                                                        && existingPerformanceEndTime <= addingPerformanceEndTime;
                var arePerformancesOverlapping = isAddingPerformanceStartTimeDuringExistingPerformance
                                                || isAddingPerformanceEndTimeDuringExistingPerformance
                                                || isAddingPerformanceOverlappingExistingPeformance;
                if (arePerformancesOverlapping)
                {
                    return true;
                }
            }

            return false;
        }
    }
}