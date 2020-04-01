using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Lab1
{
    [DataContract]
    public class Subjects
    {
        [DataMember]
        public const string _name = "Средний балл по предметам";

        [DataMember]
        public List<double> AverageSubjectMarks { get; set; }

        [DataMember]
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
            while (index < AverageSubjectMarks.Count())
            {
                AverageSubjectMarks[index] /= count;
                index++;
            }
            AverageMark = "Средняя успеваемость: " + AverageSubjectMarks.Average();
        }
    }
}
