using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string name) : base(name)
        {
            this.Town = null;
        }

        public OffsiteCourse(string name, string teacherName) : base(name, teacherName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string name, string teacherName, IList<string> students) : base(name, teacherName, students)
        {
            this.Town = null;
        }

        public string Town { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");
            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }
            result.Append(" }");

            return result.ToString();
        }
    }
}
