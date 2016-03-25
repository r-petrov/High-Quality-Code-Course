namespace Methods
{
    using System;

    internal class Methods
    {
        internal static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Triangle sides should be positive.");
            }

            if ((a + b <= c) || (a + c <= b) || (b + c <= a))
            {
                throw new ArgumentOutOfRangeException("There's no triangle with such sides' length.");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

            return area;
        }

        internal static string TransformNumberToDigit(int number)
        {
            switch (number)
            {
                case 0: 
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4: 
                    return "four";
                case 5: 
                    return "five";
                case 6: 
                    return "six";
                case 7: 
                    return "seven";
                case 8: 
                    return "eight";
                case 9: 
                    return "nine";
                default:
                    throw new ArgumentOutOfRangeException(number.ToString(), "Invalid number!");
            }
        }

        internal static int FindMaxElement(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException(elements.ToString(), "The list of integer elements is empty.");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }

        internal static void PrintFormatAsNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            } 
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException(format, "Invalid format.");
            }
        }

        internal static double CalculateDistanceBetweenTwoPoints(
            double x1, 
            double y1, 
            double x2, 
            double y2, 
            out bool isHorizontal, 
            out bool isVertical)
        {
            isHorizontal = y1 == y2;
            isVertical = x1 == x2;

            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }
        
        internal static void Main()
        {
            try
            {
                Console.WriteLine(CalculateTriangleArea(3, 4, 5));

                Console.WriteLine(TransformNumberToDigit(5));

                Console.WriteLine(FindMaxElement(5, -1, 3, 2, 14, 2, 3));

                PrintFormatAsNumber(1.3, "f");
                PrintFormatAsNumber(0.75, "%");
                PrintFormatAsNumber(2.30, "r");

                bool horizontal, vertical;
                Console.WriteLine(CalculateDistanceBetweenTwoPoints(3, -1, 3, 2.5, out horizontal, out vertical));
                Console.WriteLine("Horizontal? " + horizontal);
                Console.WriteLine("Vertical? " + vertical);

                Student peter = new Student()
                {
                    FirstName = "Peter", LastName = "Ivanov"
                };

                peter.OtherInfo = "From Sofia, born at 17.03.1992";

                Student stella = new Student()
                {
                    FirstName = "Stella", LastName = "Markova"
                };

                stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

                Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThanOtherStudent(stella));
            }
            catch (ArgumentOutOfRangeException aorex)
            {
                Console.Error.WriteLine(aorex.ParamName);
            }
            catch (ArgumentNullException anex)
            {
                Console.Error.WriteLine(anex.ParamName);
            }
            catch (ArgumentException arex)
            {
                Console.Error.WriteLine(arex.ParamName);
            }
        }
    }
}
