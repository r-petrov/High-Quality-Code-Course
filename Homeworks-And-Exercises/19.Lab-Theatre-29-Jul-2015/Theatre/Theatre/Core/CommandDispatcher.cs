namespace Theatre.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Interfaces;

    internal class CommandDispatcher : ICommandDispatcher
    {
        private IOutputWriter outputWriter;

        private IPerformanceDatabase performanceDatabase;

        public CommandDispatcher(IOutputWriter outputWriter, IPerformanceDatabase performanceDatabase)
        {
            this.OutputWriter = outputWriter;
            this.PerformanceDatabase = performanceDatabase;
        }

        public IOutputWriter OutputWriter
        {
            get
            {
                return this.outputWriter;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Output writer cannot be null");
                }

                this.outputWriter = value;
            }
        }

        public IPerformanceDatabase PerformanceDatabase
        {
            get
            {
                return this.performanceDatabase;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Performance database cannot be null");
                }

                this.performanceDatabase = value;
            }
        }

        public void DispatchCommand(string[] commandData)
        {
            var command = commandData[0];
            try
            {
                switch (command)
                {
                    case "AddTheatre":
                        var theatreToAdd = commandData[1];
                        this.PerformanceDatabase.AddTheatre(theatreToAdd);

                        break;

                    case "PrintAllTheatres":
                        var allTheatres = this.PerformanceDatabase.ListTheatres();
                        this.OutputWriter.Write(string.Join(", ", allTheatres));
                        this.OutputWriter.WriteLine();

                        break;

                    case "AddPerformance":
                        string theatreName = commandData[1].Trim();
                        string performanceTitle = commandData[2].Trim();
                        var performanceDateTime = commandData[3].Trim();
                        var formatDateTime = "dd.MM.yyyy HH:mm";
                        var culture = CultureInfo.InvariantCulture;
                        DateTime startDateTime = DateTime.ParseExact(performanceDateTime, formatDateTime, culture);
                        TimeSpan duration = TimeSpan.Parse(commandData[4].Trim());
                        var performancePrice = commandData[5].Trim();
                        var price = Convert.ToDecimal(performancePrice, CultureInfo.InvariantCulture);
                        this.PerformanceDatabase.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);

                        break;

                    case "PrintAllPerformances":
                        var allPerformances = this.PerformanceDatabase.ListAllPerformances();
                        this.OutputWriter.Write(string.Join(", ", allPerformances.Select(ap => ap.ToString())));
                        this.OutputWriter.WriteLine();

                        break;

                    case "PrintPerformances":
                        string theatre = commandData[1];
                        var theatrePerformances = this.PerformanceDatabase.ListPerformances(theatre);
                        this.OutputWriter.Write(string.Join(", ", theatrePerformances.Select(tp => tp.GetTheatrePerformance())));
                        this.OutputWriter.WriteLine();

                        break;

                    default:
                        this.OutputWriter.WriteLine(GlobalMessages.InvalidCommand);

                        break;
                }
            }
            catch (Exception ex)
            {
                this.OutputWriter.WriteLine(ex.Message);
            }
        }
    }
}
