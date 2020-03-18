using System.IO;

namespace Lab1
{
    public static class ValidationProgramArguments
    {
        public static string Validation(string inputFile, string outputFile, string outputFormat)
        {
            string message = "";            
            if (!inputFile.EndsWith(".csv"))
            {
                message = "Wrong format of input file";
            }
            else if (!outputFormat.Equals("JSON") && !outputFormat.Equals("Excel"))
            {
                message = "Wrong format of output file";
            }
            else if (!File.Exists(inputFile))
            {
                message = "Input file not exist";
            }
            return message;
        }
    }
}
