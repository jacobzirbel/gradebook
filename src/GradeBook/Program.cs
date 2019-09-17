using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Jacob's Grade Book");
            book.GradeAdded += OnGradeAdded;
            var done = false;

            while (!done)
            {
                System.Console.WriteLine("enter grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    done = true;
                    break;
                }
                try
                {
                    input = input.ToUpper();
                    char charTemp;
                    double doubleTemp;
                    if (char.TryParse(input, out charTemp) && !double.TryParse(input, out doubleTemp))
                    {
                        char grade = charTemp;
                        book.AddGrade(grade);
                    }
                    else if (double.TryParse(input, out doubleTemp))
                    {
                        double grade = doubleTemp;
                        book.AddGrade(grade);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid Input");
                    }
                }
                catch (ArgumentException Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
                catch (FormatException Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
                finally
                {
                    Console.WriteLine("***");
                }
            }
            var stats = book.GetStats();

            System.Console.WriteLine($"The letter is {stats.Letter}");
            Console.WriteLine($"The average is {stats.Average}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("a grade was added");
        }
    }
}
