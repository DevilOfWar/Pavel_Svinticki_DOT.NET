using System;

namespace Lab1
{
    public class ValidatorInputField
    {
        public static void ValidateType(string obj, bool mustBeString)
        {
            if (mustBeString)
            {
                foreach (char element in obj)
                {
                    if (!Char.IsLetter(element))
                    {
                        throw new Exception(" FIO have not a letters");
                    }
                }
            }
            else
            {
                foreach (char element in obj)
                {
                    if (!Char.IsDigit(element) || element == '-' || element == '.')
                    {
                        throw new Exception(" marks must be a positive integer.");
                    }
                }
            }
        }
    }
}
