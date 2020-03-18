using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Subjects
    {
        public const string _name = "Средний балл по предметам";
        public List<double> AverageSubjectMarks { get; set; }
        public string AverageMark { get; set; }
        public Subjects(List<Student> studentList)
        {
            AverageSubjectMarks = new List<double>();
            int count = 0;
            int index = 0;
            foreach (Student student in studentList)
            {
                index = 0;
                foreach (double mark in student.Marks)
                {
                    if (count == 0)
                    {
                        AverageSubjectMarks.Add(mark);
                    }
                    else
                    {
                        AverageSubjectMarks[index] += mark;
                    }
                    index++;
                }
                count++;
            }
            index = 0;
            foreach (double mark in AverageSubjectMarks)
            {
                AverageSubjectMarks[index] /= count;
            }
            AverageMark = "Средняя успеваемость: " + AverageSubjectMarks.Average();
        }
    }
}
