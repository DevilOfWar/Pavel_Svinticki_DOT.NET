using System.IO;
using System;

namespace Lab1
{
    public static class ValidationProgramArguments
    {
        public static void Validation(Options options)
        {           
            if (!options.InputFile.EndsWith(".csv"))
            {
                throw new Exception("Wrong format of input file");
            }
            else if (!options.OutputFileFormat.Equals("JSON") && !options.OutputFileFormat.Equals("Excel"))
            {
                throw new Exception("Wrong format of output file");
            }
            else if (!File.Exists(options.InputFile))
            {
                throw new Exception("Input file not exist");
            }
        }
    }
}
