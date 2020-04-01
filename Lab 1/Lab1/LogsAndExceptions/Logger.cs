using System.IO;

namespace Lab1
{
    public static class Logger
    {
        public static string lastMessage { get; private set; }
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
