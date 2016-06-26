namespace Theatre
{
    using System;

    public class Performance
    {
        private string theatre;
        private string name;
        private DateTime dateAndTime;
        private TimeSpan duration;
        private decimal price;

        public Performance(string theatre, string name, DateTime dateAndTime, TimeSpan duration, decimal price)
        {
            this.Theatre = theatre;
            this.Name = name;
            this.DateAndTime = dateAndTime;
            this.Duration = duration;
            this.Price = price;
        }

        public string Theatre
        {
            get
            {
                return this.theatre;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Theatre name can not be null or empty!");
                }

                this.theatre = value;
            }
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
                    throw new ArgumentNullException("Performance name can not be null or empty!");
                }

                this.name = value;
            }
        }

        public DateTime DateAndTime
        {
            get
            {
                return this.dateAndTime;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Performance start date and time can not be null or empty!");
                }

                this.dateAndTime = value;
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return this.duration;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Performance duration can not be null or empty!");
                }

                this.duration = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Performance price can not have negative value!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            var output = string.Format(
                "({0}, {1}, {2})",
                this.Name,
                this.Theatre,
                this.DateAndTime.ToString("dd.MM.yyyy HH:mm"));

            return output;
        }

        public string GetTheatrePerformance()
        {
            var output = string.Format(
                "({0}, {1})",
                this.Name,
                this.DateAndTime.ToString("dd.MM.yyyy HH:mm"));

            return output;
        }
    }
}