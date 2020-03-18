namespace Lab1
{
    public class ValidatorInputField
    {
        public static int ValidateType(string obj, bool mustBeString)
        {
            if (mustBeString)
            {
                foreach (char element in obj)
                {
                    if (!((element >= 'a' && element <='я') || (element >= 'А' && element <= 'Я') || (element >= 'a' && element <= 'z') || (element >= 'A' && element <= 'Z')))
                    {
                        return 1;
                    }
                }
            }
            else
            {
                string marks = "0123456789";
                if (!(obj.Length == 1 && marks.Contains(obj) || obj.Equals("10")))
                {
                    return 2;
                }
            }
            return 0;
        }
    }
}
