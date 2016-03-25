namespace Logger.Appenders
{
    using System;
    using Contracts;

    public abstract class Appender : IAppender
    {
        private ILayout layout;

        protected Appender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel = ReportLevel.Default;
        }

        public ILayout Layout
        {
            get
            {
                return this.layout;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The logger layout cannot be empty.");
                }

                this.layout = value;
            }
        }

        public ReportLevel ReportLevel { get; set; }

        public abstract void AppendMessage(ReportLevel reportLevel, string message);
    }
}