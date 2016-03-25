namespace Logger.Layouts
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Contracts;

    public abstract class Layout : ILayout
    {
        protected Layout()
        {
            this.CurrentDateTime = this.ConvertDateTime();
        }

        protected string CurrentDateTime { get; private set; }

        public abstract string DefineFormat(ReportLevel reportLevel, string message);

        private string ConvertDateTime()
        {
            string culture = "en-US";
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            var result = DateTime.Now;

            return result.ToString();
        }
    }
}
