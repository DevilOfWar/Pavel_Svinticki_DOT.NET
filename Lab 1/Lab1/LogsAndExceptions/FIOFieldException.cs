using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.LogsAndExceptions
{
    public class FIOFieldException : Exception
    {
        public FIOFieldException()
        {

        }
        public FIOFieldException(string message) : base(message)
        {

        }
    }
}
