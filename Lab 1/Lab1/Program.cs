using System.Collections.Generic;
using CommandLine;
using System;
using Lab1.LogsAndExceptions;

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
            try
            {
                ValidationProgramArguments.Validation(options);
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
                        throw new IOSystemException("Wrong output format");
                    }
                }
                else if (file == null)
                {
                    throw new IOSystemException("File not found");                    
                }
                else
                {
                    throw new IOSystemException("File don't have any correct line.");
                }
            }
            catch (IOSystemException ex)
            {
                Logger.Log("Input/Output System exception: " + ex.Message);
            }
            catch (FieldNameException ex)
            {
                Logger.Log("Field Name Exception: " + ex.Message);
            }
            catch (FIOFieldException ex)
            {
                Logger.Log("FIO Exception: " + ex.Message);
            }
            catch (MarkFieldException ex)
            {
                Logger.Log("Mark Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log("Unexeptable Exception:" + ex.Message);
            }
        }
    }
}
