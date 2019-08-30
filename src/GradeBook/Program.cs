using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Jacob's Grade Book");
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.5);
            var done = false;
            do
            {
                System.Console.WriteLine("enter grade or 'q' to quit");
                var input = Console.ReadLine();
                if(input == "q")
                {
                    done = true;
                    continue;
                }

                try
                {
                var grade = double.Parse(input);
                book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //run this no matter what
                    Console.WriteLine("***");
                }

            }while(!done);

            var stats = book.GetStats();

            System.Console.WriteLine($"The letter is {stats.Letter}");
            Console.WriteLine($"The average is {stats.Average}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
        }
    }
}
