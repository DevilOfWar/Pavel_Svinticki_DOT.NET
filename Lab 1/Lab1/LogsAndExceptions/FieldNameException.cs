using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.LogsAndExceptions
{
    public class FieldNameException : Exception
    {
        public FieldNameException()
        {

        }
        public FieldNameException(string message) : base(message)
        {

        }
    }
}
