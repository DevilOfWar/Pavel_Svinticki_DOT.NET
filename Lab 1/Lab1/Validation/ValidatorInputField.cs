using Lab1.LogsAndExceptions;

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
                    if (!char.IsLetter(element))
                    {
                        throw new FIOFieldException(" FIO have not a letters");
                    }
                }
            }
            else
            {
                foreach (char element in obj)
                {
                    if (!char.IsDigit(element) || element == '-' || element == '.')
                    {
                        throw new MarkFieldException(" marks must be a positive integer.");
                    }
                }
                if (obj == "" || obj == null)
                {
                    throw new MarkFieldException(" marks can't be emtry");
                }
            }
        }
    }
}
