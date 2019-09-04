using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Jacob's Grade Book");
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
                   char charTemp;
                   double doubleTemp;
                   if(char.TryParse(input, out charTemp) && !double.TryParse(input, out doubleTemp))
                   {
                       char grade = charTemp;
                       book.AddGrade(grade);
                   }
                   else if(double.TryParse(input, out doubleTemp))
                   {
                       double grade = doubleTemp;
                       book.AddGrade(grade);
                   }
                   else
                   {
                        throw new ArgumentException("Invalid Input");
                   }
              
                }
                catch(ArgumentException Ex)
                {
                   Console.WriteLine(Ex.Message);
                }
                catch(FormatException Ex)
                {
                   Console.WriteLine(Ex.Message);
                }
                finally
                {
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
