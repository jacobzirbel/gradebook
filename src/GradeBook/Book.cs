using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class Book 
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddLetterGrade(char letter)
        {
            
        }
        public void AddGrade(double grade)
        {
            if( grade <= 100 && grade >= 0)
            {
               grades.Add(grade);
            }
            else
            {
                Console.WriteLine("invalid value");
            }
        
        }
    
        public Stats GetStats()
        {
            var result = new Stats();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            
            var j = 0;
            for(var i = 0; i < grades.Count; i++) 
            {      
                result.Low = Math.Min(grades[i], result.Low);
                result.High = Math.Max(grades[i], result.High);
                result.Average += grades[i];
                j = i+1;
            };

            result.Average /= j;

            return result; 
        }
        private List<double> grades;
        public string Name;
    }
}   

