using System.Collections.Generic;
using CommandLine;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {            
            Options options = new Options();
            Parser.Default.ParseArguments<Options>(args).WithParsed((Options parsedOptions) => { options = parsedOptions; });
            if (options.InputFile.Equals(""))
            {
                options.InputFile = @"...\File.csv";
            }
            if (options.OutputFile.Equals(""))
            {
                options.OutputFile = @"...\File_out";
            }
            if (options.OutputFileFormat.Equals(""))
            {
                options.OutputFileFormat = "Excel";
            }
            if (!options.OutputFile.EndsWith(".xlsx") && options.OutputFileFormat.Equals("Excel"))
            {
                options.OutputFile += ".xlsx";
            }
            else if (!options.OutputFile.EndsWith(options.OutputFileFormat.ToLower()))
            {
                options.OutputFile += "." + options.OutputFileFormat.ToLower();
            }
            string validationResult = ValidationProgramArguments.Validation(options);
            if (validationResult.Equals(""))
            {
                List<string> strList = new List<string>();
                List<Student> file = Reader.ReadFile(options.InputFile, out strList);
                if (file != null && file.Count != 0)
                {
                    if (options.OutputFileFormat.Equals("JSON"))
                    {
                        WriterJSON writer = new WriterJSON();
                        writer.Write(file, strList, options.OutputFile);
                    }
                    else if (options.OutputFileFormat.Equals("Excel"))
                    {
                        WriterExcel writer = new WriterExcel();
                        writer.Write(file, strList, options.OutputFile);
                    }
                    else
                    {
                        Logger.Log("Wrong output format");
                    }
                }
                else if (file == null)
                {
                    if (!(Logger.lastMessage.EndsWith("Wrong name of first 3 columns") || Logger.lastMessage.EndsWith(" not enouch columns")))
                    {
                        Logger.Log("File not found");
                    }
                }
                else
                {
                    Logger.Log("File don't have any correct line");
                }
            }
            else
            {
                Logger.Log(validationResult);
            }
        }
    }
}
