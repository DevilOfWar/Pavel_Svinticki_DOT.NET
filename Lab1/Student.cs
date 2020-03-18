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
        public string SecondName { get; set; }

        [DataMember]
        public string NameByFather { get; set; }

        [DataMember]
        public List<double> Marks { get; set; }

        [DataMember]
        public double AverageMark => Marks.Average();
    }
}
