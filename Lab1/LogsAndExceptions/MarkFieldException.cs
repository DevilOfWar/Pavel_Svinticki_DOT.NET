using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.LogsAndExceptions
{
    public class MarkFieldException : Exception
    {
        public MarkFieldException()
        {

        }
        public MarkFieldException(string message) : base(message)
        {

        }
    }
}
