using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab1
{
    class Reader
    {
        static public List<Student> ReadFile(string fileName, out List<string> columnName)
        {
            columnName = new List<string>();
            if (File.Exists(fileName))
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    List<Student> list = new List<Student>();
                    bool firstString = true;
                    int index = 1;
                    while (!streamReader.EndOfStream)
                    {
                        string str = streamReader.ReadLine();
                        List<string> strList = str.Split(new char[]{ ',', ';'}).ToList();
                        if (firstString)
                        {
                            try
                            {
                                ValidationInput.Validate(str);
                            }
                            catch (Exception ex)
                            {
                                Logger.Log(fileName + ex.Message);
                            }
                        }
                        else
                        {
                            Student newStudent = new Student();
                            if (strList.Count() >= 3)
                            {
                                bool errorFlag = false;
                                try
                                {
                                    ValidatorInputField.ValidateType(strList[1], true);
                                    newStudent.Name = strList[1];
                                    ValidatorInputField.ValidateType(strList[0], true);
                                    newStudent.SurName = strList[0];
                                    ValidatorInputField.ValidateType(strList[2], true);                                    
                                    newStudent.MiddleName = strList[2];
                                    if (strList.Count() > columnName.Count())
                                    {
                                        throw new Exception(" " + index + " line have too many marks.");
                                    }
                                    else if (strList.Count() < columnName.Count())
                                    {
                                        throw new Exception(" " + index + " line have too low marks.");
                                    }
                                    else
                                    {
                                        newStudent.Marks = new List<double>();
                                        for (int indexList = 3; indexList < strList.Count() && !errorFlag; indexList++)
                                        {
                                            ValidatorInputField.ValidateType(strList[indexList], false);
                                            newStudent.Marks.Add(Convert.ToInt16(strList[indexList]));                                            
                                        }
                                        list.Add(newStudent);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Log(fileName + " " + index + ex.Message);
                                }
                            }
                            else
                            {
                                Logger.Log(fileName + " " + index + " line have too low count of fields: not full FIO.");
                            }
                        }
                        index++;
                    }
                    return list;
                }
            }
            else return null;
        }
    }
}
