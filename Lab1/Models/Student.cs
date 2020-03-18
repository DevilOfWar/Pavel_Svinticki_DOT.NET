using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Lab1
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string SurName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public List<double> Marks { get; set; }

        [DataMember]
        public double AverageMark
        {
            get
            {
                return Marks.Average();
            }
            set
            {
                AverageMark = Marks.Average();
            }
        }
    }
}
