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

                // if(input == "A" || input == "B" || input == "C" || input == "D" || input == "F" || input == "a" || input == "b" || input == "c" || input == "d" || input == "f")
                // {
                //     input = input.ToUpper();
                //     char grade = char.Parse(input);
                //     book.AddGrade(grade);
                //     continue;
                // }
                
                try
                {
                    input = input.ToUpper();
                    char grade = char.Parse(input);
                    book.AddGrade(grade);
                    continue;
                }
                catch(FormatException)
                {
                   Console.WriteLine("format 1 exception");
                }
                finally
                {
                    try
                    {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    }
                    catch(ArgumentException)
                    {
                        Console.WriteLine("argument exception");
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("format exception");
                    }
                    finally
                    {
                        Console.WriteLine("***");
                    }
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
