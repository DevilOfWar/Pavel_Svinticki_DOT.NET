using System.IO;
using System.Collections.Generic;
using OfficeOpenXml;

namespace Lab1
{
    public class WriterExcel : IWriter
    {
        public WriterExcel() : base()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public void Write(List<Student> list, List<string> columnName, string file)
        {
            ExcelPackage excel = new ExcelPackage();
            ExcelWorkbook workBook = excel.Workbook;
            ExcelWorksheet workSheet = workBook.Worksheets.Add(file);
            int indexColumn = 1;
            int indexLine = 1;
            foreach (string column in columnName)
            {
                workSheet.Cells[indexLine, indexColumn].Value = column;
                indexColumn++;
            }
            workSheet.Cells[indexLine, indexColumn].Value = "Средний балл студента";
            indexLine++;
            foreach (Student student in list)
            {
                indexColumn = 1;
                workSheet.Cells[indexLine, indexColumn].Value = student.SurName;
                indexColumn++;
                workSheet.Cells[indexLine, indexColumn].Value = student.Name;
                indexColumn++;
                workSheet.Cells[indexLine, indexColumn].Value = student.MiddleName;
                indexColumn++;
                foreach (double mark in student.Marks)
                {
                    workSheet.Cells[indexLine, indexColumn].Value = mark;
                    indexColumn++;
                }
                workSheet.Cells[indexLine, indexColumn].Value = student.AverageMark;
                indexLine++;
            }
            Subjects AverageSubject = new Subjects(list);
            workSheet.Cells[indexLine, 1].Value = Subjects._name;
            indexColumn = 4;
            foreach (double mark in AverageSubject.AverageSubjectMarks)
            {
                workSheet.Cells[indexLine, indexColumn].Value = mark;
                indexColumn++;
            }
            workSheet.Cells[indexLine, indexColumn].Value = AverageSubject.AverageMark;
            excel.SaveAs(new FileInfo(file));
            workSheet.Dispose();
            workBook.Dispose();
            excel.Dispose();
        }
    }
}
