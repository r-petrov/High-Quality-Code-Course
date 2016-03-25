namespace Logger.Appenders
{
    using System;
    using Contracts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void AppendMessage(ReportLevel reportLevel, string message)
        {
            var result = this.Layout.DefineFormat(reportLevel, message);
            Console.WriteLine(result);
        }
    }
}
