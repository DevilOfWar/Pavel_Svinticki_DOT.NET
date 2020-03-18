using System.IO;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "";
            string outputFile = "";
            string outputFileFormat = "";
            bool inputFileFlag = false;
            bool outputFileFlag = false;
            bool outputFormatFlag = false;
            foreach (string line in args)
            {
                if (line.Equals("-inputFile"))
                {
                    inputFileFlag = true;
                    outputFileFlag = false;
                    outputFormatFlag = false;
                }
                else if (line.Equals("-outputFile"))
                {
                    inputFileFlag = false;
                    outputFileFlag = true;
                    outputFormatFlag = false;
                }
                else if (line.Equals("-outputFormat"))
                {
                    inputFileFlag = false;
                    outputFileFlag = false;
                    outputFormatFlag = true;
                }
                else if (inputFileFlag)
                {
                    inputFile = line;
                    inputFileFlag = false;
                }
                else if (outputFileFlag)
                {
                    outputFile = line;
                    outputFileFlag = false;
                }
                else if (outputFormatFlag)
                {
                    outputFileFormat = line;
                    outputFormatFlag = false;
                }
            }
            if (inputFile.Equals(""))
            {
                inputFile = @"...\File.csv";
            }
            if (outputFile.Equals(""))
            {
                outputFile = @"...\File_out";
            }
            if (outputFileFormat.Equals(""))
            {
                outputFileFormat = "Excel";
            }
            if (!outputFile.EndsWith(".xlsx") && outputFileFormat.Equals("Excel"))
            {
                outputFile += ".xlsx";
            }
            else if (!outputFile.EndsWith(outputFileFormat.ToLower()))
            {
                outputFile += "." + outputFileFormat.ToLower();
            }
            string validationResult = ValidationProgramArguments.Validation(inputFile, outputFile, outputFileFormat);
            if (validationResult.Equals(""))
            {
                List<string> strList = new List<string>();
                List<Student> file = Reader.ReadFile(inputFile, out strList);
                if (file != null && file.Count != 0)
                {
                    if (outputFileFormat.Equals("JSON"))
                    {
                        WriterJSON writer = new WriterJSON();
                        writer.Write(file, strList, outputFile);
                    }
                    else if (outputFileFormat.Equals("Excel"))
                    {
                        WriterExcel writer = new WriterExcel();
                        writer.Write(file, strList, outputFile);
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
