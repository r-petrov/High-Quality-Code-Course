namespace Logger
{
    using Layouts;

    public class SimpleLayout : Layout
    {
        public override string DefineFormat(ReportLevel reportLevel, string message)
        {
            var result = string.Format("{0} - {1} - {2}", this.CurrentDateTime, reportLevel, message);
            return result;
        }
    }
}
