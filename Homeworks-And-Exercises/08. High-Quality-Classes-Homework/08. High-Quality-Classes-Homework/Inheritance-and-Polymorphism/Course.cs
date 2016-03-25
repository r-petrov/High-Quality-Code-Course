using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public abstract class Course
    {
        private string name;

        protected Course(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.Students = new List<string>();
        }

        protected Course(string name, string teacherName)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = new List<string>();
        }

        protected Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public string TeacherName { get; set; }

        public IList<string> Students { get; set; }

        protected string GetStudentsAsString()
        {
            if (this.Students.Count > 0)
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
            else
            {
                return "{ }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            
            return result.ToString();
        }
    }
}