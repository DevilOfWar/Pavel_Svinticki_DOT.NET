using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class Logger
    {
        public static string lastMessage;
        public static void Log(string message)
        {
            using (StreamWriter file = new StreamWriter("D:\\logs.log", true))
            {
                file.WriteLine(message);
                lastMessage = message;
            }
        }
    }
}
