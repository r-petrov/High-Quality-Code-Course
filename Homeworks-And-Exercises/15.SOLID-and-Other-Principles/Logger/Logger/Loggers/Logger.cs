namespace Logger.Loggers
{
    using System;
    using Contracts;

    public class Logger : ILogger
    {
        private IAppender[] appender;

        public Logger(params IAppender[] appender)
        {
            this.Appender = appender;
        }

        public IAppender[] Appender
        {
            get
            {
                return this.appender;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Log appender cannot be empty.");
                }

                this.appender = value;
            }
        }

        public void Info(string message)
        {
            this.AppendMessages(ReportLevel.Info, message);
        }

        public void Warn(string message)
        {
            this.AppendMessages(ReportLevel.Warning, message);
        }

        public void Error(string message)
        {
            this.AppendMessages(ReportLevel.Error, message);
        }

        public void Critical(string message)
        {
            this.AppendMessages(ReportLevel.Critical, message);
        }

        public void Fatal(string message)
        {
            this.AppendMessages(ReportLevel.Fatal, message);
        }

        private void AppendMessages(ReportLevel reportLevel, string message)
        {
            foreach (var currentAppender in this.Appender)
            {
                if (currentAppender.ReportLevel >= reportLevel)
                {
                    currentAppender.AppendMessage(reportLevel, message);
                }
            }
        }
    }
}
