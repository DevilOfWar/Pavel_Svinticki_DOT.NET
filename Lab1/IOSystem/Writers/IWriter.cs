using System.Collections.Generic;

namespace Lab1
{
    interface IWriter
    {
        void Write(List<Student> list, List<string> columnName, string file);
    }
}
