namespace Logger.Contracts
{
    public interface ILayout
    {
        string DefineFormat(ReportLevel reportLevel, string message);
    }
}