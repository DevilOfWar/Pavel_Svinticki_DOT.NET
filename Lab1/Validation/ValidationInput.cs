using System.Collections.Generic;
using System.Linq;
using Lab1.LogsAndExceptions;

namespace Lab1
{
    public class ValidationInput
    {
        static public void Validate(string obj)
        {
            List<string> list = obj.Split(',').ToList();
            if (list.Count() < 3)
            {
                throw new FieldNameException(" not enouch columns");
            }
            if ((!list[0].Equals("Фамилия") || !list[1].Equals("Имя") || !list[2].Equals("Отчество")) && (!list[0].Equals("Surname") || !list[1].Equals("Name") || !list[2].Equals("Middle Name")))
            {
                throw new FieldNameException(" Wrong name of first 3 columns");
            }
        }
    }
}
