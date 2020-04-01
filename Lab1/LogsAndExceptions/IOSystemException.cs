using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.LogsAndExceptions
{
    public class IOSystemException : Exception
    {
        public IOSystemException()
        {

        }
        public IOSystemException(string message) : base(message)
        {

        }
    }
}
