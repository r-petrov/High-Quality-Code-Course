namespace Theatre
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    internal class Theatre : ITheatre
    {
        private string name;

        public Theatre(string name)
        {
            this.Name = name;
            this.Timetable = new List<Performance>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Theatre name can not be null or empty!");
                }

                this.name = value;
            }
        }

        public ICollection<Performance> Timetable { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            foreach (var performance in this.Timetable)
            {
                var line = performance.Name + this.Name;
                output.AppendLine(line);
            }

            return output.ToString();
        }
    }
}
