# Lab1

There is first lab of subject.

Quest: Make console programm, what can read .csv files with students data, processing this data and output in one of two format: JSON or Excel.

Used NuGet packages: CommandLineParser, EPPlus.

Created classes and interfaces: IWriter, WriterJSON, WriterExcel, Logger, Options, Subjects, Student, ValidationInput, ValidationProgrammArguments,
ValidationInputField.

To run application, use console command in format: <path_to_exe_file> -i <path_to_input_file> -o <path_to_output_file> -f <format_of_output_file>. If path_of_input_file and path_to_output_file don't have correct format, it will be added to correct form. For input file - .csv, for output - .json or .xlsx. By default, output format is Excel, output file - File_out in application directory, input file - File.csv in application directory.
