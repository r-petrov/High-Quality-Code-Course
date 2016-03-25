namespace Logger.Contracts
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        void AppendMessage(ReportLevel reportLevel, string message);
    }
}