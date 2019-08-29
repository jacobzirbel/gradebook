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

        public void AddGrade(double grade)
        {
           grades.Add(grade);
        }
    
        public Stats GetStats()
        {
            var result = new Stats();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach(double grade in grades) 
            {
                if(grade > result.High)
                {
                    result.High = grade;
                }
                if(grade < result.Low)
                {
                    result.Low = grade;
                }
                result.Average += grade;
            }
            result.Average /= grades.Count;

            return result; 
        }
        private List<double> grades;
        public string Name;
    }
}   

