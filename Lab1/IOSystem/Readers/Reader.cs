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
                    int markCount = 0;
                    List<Student> list = new List<Student>();
                    bool firstString = true;
                    int index = 1;
                    while (!streamReader.EndOfStream)
                    {
                        string str = streamReader.ReadLine();
                        List<string> strList = str.Split(new char[]{ ',', ';'}).ToList();
                        if (firstString)
                        {
                            if (ValidationInput.Validate(str) == 0)
                            {
                                firstString = false;
                                columnName = strList;
                                markCount = strList.Count() - 3;
                            }
                            else if (ValidationInput.Validate(str) == 1)
                            {
                                Logger.Log(fileName + " not enouch columns");
                                return null;
                            }
                            else
                            {
                                Logger.Log(fileName + "Wrong name of first 3 columns");
                                return null;
                            }
                        }
                        else
                        {
                            Student newStudent = new Student();
                            if (strList.Count() >= 3)
                            {
                                bool errorFlag = false;
                                if (ValidatorInputField.ValidateType(strList[1], true) == 0)
                                {
                                    newStudent.Name = strList[1];
                                }
                                else
                                {
                                    errorFlag = true;
                                }
                                if (ValidatorInputField.ValidateType(strList[0], true) == 0)
                                {
                                    newStudent.SecondName = strList[0];
                                }
                                else
                                {
                                    errorFlag = true;
                                }
                                if (ValidatorInputField.ValidateType(strList[2], true) == 0)
                                {
                                    newStudent.NameByFather = strList[2];
                                }
                                else
                                {
                                    errorFlag = true;
                                }
                                if (strList.Count() > columnName.Count())
                                {
                                    Logger.Log(fileName + " " + index + " line have too many marks.");
                                }
                                else if (strList.Count() < columnName.Count())
                                {
                                    Logger.Log(fileName + " " + index + " line have too low marks.");
                                }
                                else
                                {
                                    newStudent.Marks = new List<double>();
                                    for (int indexList = 3; indexList < strList.Count() && !errorFlag; indexList++)
                                    {
                                        if (ValidatorInputField.ValidateType(strList[indexList], false) == 0)
                                        {
                                            newStudent.Marks.Add(Convert.ToInt16(strList[indexList]));
                                        }
                                        else
                                        {
                                            errorFlag = true;
                                        }
                                    }
                                    if (!errorFlag)
                                    {
                                        list.Add(newStudent);
                                    }
                                    else
                                    {
                                        Logger.Log(fileName + " " + index + " line have wrong format of data");
                                    }
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
