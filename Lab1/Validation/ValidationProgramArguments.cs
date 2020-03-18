using System.IO;

namespace Lab1
{
    public static class ValidationProgramArguments
    {
        public static string Validation(Options options)
        {
            string message = "";            
            if (!options.InputFile.EndsWith(".csv"))
            {
                message = "Wrong format of input file";
            }
            else if (!options.OutputFileFormat.Equals("JSON") && !options.OutputFileFormat.Equals("Excel"))
            {
                message = "Wrong format of output file";
            }
            else if (!File.Exists(options.InputFile))
            {
                message = "Input file not exist";
            }
            return message;
        }
    }
}
