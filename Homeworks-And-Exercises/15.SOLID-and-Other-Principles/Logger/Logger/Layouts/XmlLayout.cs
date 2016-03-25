namespace Logger.Layouts
{
    using System.Text;

    public class XmlLayout : Layout
    {
        public override string DefineFormat(ReportLevel reportLevel, string message)
        {
            var result = new StringBuilder();
            result.AppendLine("<log>");
            result.AppendLine(string.Format("\t<date>{0}</date>", this.CurrentDateTime));
            result.AppendLine(string.Format("\t<level>{0}</level>", reportLevel));
            result.AppendLine(string.Format("\t<message>{0}</message>", message));
            result.Append("</log>");

            return result.ToString();
        }
    }
}
