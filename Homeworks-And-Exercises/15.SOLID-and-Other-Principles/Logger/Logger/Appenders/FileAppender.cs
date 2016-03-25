namespace Logger.Appenders
{
    using System;
    using Contracts;
    using sysIO = System.IO;
    
    public class FileAppender : Appender
    {
        private string file;
        private string path;

        public FileAppender(ILayout layout) : base(layout)
        {
            this.File = "testLog.txt";
            this.Path = string.Format(
                "D:\\SoftUni\\Courses\\programming_fundamentals\\High-Quality-Code\\Homeworks-And-Exercises\\15.SOLID-and-Other-Principles\\Logger\\{0}",
                this.File);
        }

        public string File
        {
            get
            {
                return this.file;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("File name cannot be null, empty or white space.");
                }

                this.file = value;
            }
        }

        public string Path
        {
            get
            {
                return this.path;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("File path cannot be null, empty or white space.");
                }

                this.path = value;
            }
        }

        public override void AppendMessage(ReportLevel reportLevel, string message)
        {
            if (this.File == null || this.Path == null)
            {
                throw new ArgumentNullException("File name and path cannot be null, empty or whitespace.");
            }

   /*         string path = string.Format(
                "D:\\SoftUni\\Courses\\programming_fundamentals\\High-Quality-Code\\Homeworks-And-Exercises\\15.SOLID-and-Other-Principles\\Logger\\{0}", 
                this.File);*/
            var result = this.Layout.DefineFormat(reportLevel, message);
            sysIO.File.AppendAllText(this.Path, result);
        }
    }
}
