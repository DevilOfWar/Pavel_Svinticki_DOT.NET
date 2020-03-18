using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Lab1
{
    public class WriterJSON : IWriter
    {
        public void Write(List<Student> list, List<string> columnName, string file)
        {            
            using (FileStream stream = new FileStream(file, FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer serializerStudent = new DataContractJsonSerializer(typeof(List<Student>));
                serializerStudent.WriteObject(stream, list);
                DataContractJsonSerializer serializerSubjects = new DataContractJsonSerializer(typeof(Subjects));
                serializerSubjects.WriteObject(stream, new Subjects(list));
            }
        }                
    }
}
