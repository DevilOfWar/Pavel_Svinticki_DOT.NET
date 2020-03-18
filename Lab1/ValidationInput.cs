using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    public class ValidationInput
    {
        static public int Validate(string obj)
        {
            List<string> list = obj.Split(',').ToList();
            if (list.Count() < 3)
            {
                return 1;
            }
            if ((!list[0].Equals("Фамилия") || !list[1].Equals("Имя") || !list[2].Equals("Отчество")) && (!list[0].Equals("Surname") || !list[1].Equals("Name") || !list[2].Equals("Middle Name")))
            {
                return 2;
            }
            return 0;
        }
    }
}
