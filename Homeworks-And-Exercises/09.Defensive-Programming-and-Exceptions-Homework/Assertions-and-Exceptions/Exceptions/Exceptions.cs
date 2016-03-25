using System;
using System.Collections.Generic;
using System.Text;

class Exceptions
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentNullException("The input array is not initialized!");
        }

        if (startIndex < 0)
        {
            throw new IndexOutOfRangeException("The start index should be nonnegative.");
        }

        if (count < 0 || startIndex + count > arr.Length)
        {
            throw new ArgumentOutOfRangeException(count < 0 ?
                "The parameter count should be nonnegative" :
                "The sum of start index value and parameter count cannot be bigger than the length of input array.");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (string.IsNullOrEmpty(str))
        {
            throw new ArgumentNullException("The input string is null or empty.");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("The parameter count should be nonnegative.");
        }

        if (count > str.Length)
        {
            // return "Invalid count!";

            throw new ArgumentOutOfRangeException("The parameter count cannot be bigger than the length of input string.");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException("The input number should be nonnegative.");
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                Console.WriteLine("The number is not prime!");
                break;
            }
        }
    }

    static void Main()
    {
        try
        {
            var substr = Subsequence("Hello!".ToCharArray(), -2, 3);
            Console.WriteLine(substr);
        }
        catch (ArgumentNullException argNullEx)
        {
            Console.Error.WriteLine(argNullEx.ParamName);
        }
        catch (IndexOutOfRangeException iorex)
        {
            Console.Error.WriteLine(iorex.Data);
        }
        catch (ArgumentOutOfRangeException aorex)
        {
            Console.Error.WriteLine(aorex.ParamName);
        }

        try
        {
            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));
        }
        catch (ArgumentNullException argNullEx)
        {
            Console.Error.WriteLine(argNullEx.ParamName);
        }
        catch (IndexOutOfRangeException iorex)
        {
            Console.Error.WriteLine(iorex.Data);
        }
        catch (ArgumentOutOfRangeException aorex)
        {
            Console.Error.WriteLine(aorex.ParamName);
        } 
        
        try
        {
            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));
        }
        catch (ArgumentNullException argNullEx)
        {
            Console.Error.WriteLine(argNullEx.ParamName);
        }
        catch (IndexOutOfRangeException iorex)
        {
            Console.Error.WriteLine(iorex.Data);
        }
        catch (ArgumentOutOfRangeException aorex)
        {
            Console.Error.WriteLine(aorex.ParamName);
        } 
        
        try
        {
            var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));
        }
        catch (ArgumentNullException argNullEx)
        {
            Console.Error.WriteLine(argNullEx.ParamName);
        }
        catch (IndexOutOfRangeException iorex)
        {
            Console.Error.WriteLine(iorex.Data);
        }
        catch (ArgumentOutOfRangeException aorex)
        {
            Console.Error.WriteLine(aorex.ParamName);
        }

        try
        {
            Console.WriteLine(ExtractEnding("I love C#", 2));
        }
        catch (ArgumentNullException argNullEx)
        {
            Console.Error.WriteLine(argNullEx.ParamName);
        }
        catch (ArgumentOutOfRangeException aorex)
        {
            Console.Error.WriteLine(aorex.ParamName);
        }

        try
        {
            Console.WriteLine(ExtractEnding("Nakov", 4));
        }
        catch (ArgumentNullException argNullEx)
        {
            Console.Error.WriteLine(argNullEx.ParamName);
        }
        catch (ArgumentOutOfRangeException aorex)
        {
            Console.Error.WriteLine(aorex.ParamName);
        }

        try
        {
            Console.WriteLine(ExtractEnding("beer", 4));
        }
        catch (ArgumentNullException argNullEx)
        {
            Console.Error.WriteLine(argNullEx.ParamName);
        }
        catch (ArgumentOutOfRangeException aorex)
        {
            Console.Error.WriteLine(aorex.ParamName);
        }

        try
        {
            Console.WriteLine(ExtractEnding("Hi", 100));
        }
        catch (ArgumentNullException argNullEx)
        {
            Console.Error.WriteLine(argNullEx.ParamName);
        }
        catch (ArgumentOutOfRangeException aorex)
        {
            Console.Error.WriteLine(aorex.ParamName);
        }

        try
        {
            CheckPrime(23);
            Console.WriteLine("23 is prime.");
        }
        catch (ArgumentOutOfRangeException aorex)
        {
            Console.WriteLine(aorex.ParamName);
        }

        try
        {
            CheckPrime(33);
            Console.WriteLine("33 is prime.");
        }
        catch (ArgumentOutOfRangeException aorex)
        {
            Console.WriteLine(aorex.ParamName);
        }

        try
        {
            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
        catch (ArgumentOutOfRangeException aorex)
        {
            Console.Error.WriteLine(aorex.ParamName);
        }
        catch (ArgumentNullException argNullEx)
        {
            Console.Error.WriteLine(argNullEx.ParamName);
        }
        catch (NullReferenceException nullRefEx)
        {
            Console.Error.WriteLine(nullRefEx.Data);
        }
        catch (ArgumentException aex)
        {
            Console.Error.WriteLine(aex.ParamName);
        }
    }
}
