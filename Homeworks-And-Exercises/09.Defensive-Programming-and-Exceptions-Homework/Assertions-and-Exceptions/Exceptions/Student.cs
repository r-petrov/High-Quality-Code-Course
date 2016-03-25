using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;

    private string lastName;

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        //if (firstName == null)
        //{
        //    Console.WriteLine("Invalid first name!");
        //    Environment.Exit(0);
        //}

        //if (lastName == null)
        //{
        //    Console.WriteLine("Invalid first name!");
        //    Environment.Exit(0);
        //}

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Student's first name cannot be null or empty.");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Student's last name cannot be null or empty.");
            }

            this.lastName = value;
        }
    }
    public IList<Exam> Exams { get; set; }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new NullReferenceException("The list of exams has null value.");
        }

        if (this.Exams.Count == 0)
        {
            throw new ArgumentException("The student has no exams!");
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            // Cannot calculate average on missing exams
            throw new NullReferenceException("The list of exams has null value.");
        }

        if (this.Exams.Count == 0)
        {
            // No exams --> return -1;
            return -1;
        }

        double[] examScores = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScores[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScores.Average();
    }
}
